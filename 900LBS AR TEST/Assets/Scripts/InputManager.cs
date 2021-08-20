using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] private ARManager ARManager;
    [SerializeField] private float touchScaleSpeed = 2f;
    [SerializeField] private float touchRotateSpeed = 100f;
    [SerializeField] private float touchMoveSpeed = 2f;

    private float initialDistance, touchStartingPosition;
    private Vector3 initialScale;

    void Update()
    {
        //CheckForTouch(); //old implementation for touch rotation and object scaling. Only works with default input system
        CheckForMove();
        CheckForRotate();
    }

    private void CheckForTouch()
    {
        //Pinch-to-zoom and rotation via touch with default input system.
        if (Input.touchCount == 1)
        {
            if (IsPointOverUIObject(Input.GetTouch(0).position))
            {
                return;
            }

            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartingPosition = touch.position.x;
                    break;
                case TouchPhase.Moved:
                    if (touchStartingPosition > touch.position.x)
                    {
                        ARManager.model.transform.Rotate(Vector3.up, (touchRotateSpeed * touchRotateSpeed) * Time.deltaTime);
                    }
                    else if (touchStartingPosition < touch.position.x)
                    {
                        ARManager.model.transform.Rotate(Vector3.up, (-touchRotateSpeed * touchRotateSpeed) * Time.deltaTime);
                    }
                    break;
                case TouchPhase.Ended:
                    break;
            }
        }

        if (Input.touchCount == 2)
        {
            var touch1 = Input.GetTouch(0);
            var touch2 = Input.GetTouch(1);
            
            if(touch1.phase == TouchPhase.Ended || touch1.phase == TouchPhase.Canceled ||
               touch2.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Canceled)
            {
                return;
            }

            if(touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touch1.position, touch2.position);
                initialScale = ARManager.model.transform.localScale;
            }
            else
            {
                var currentDistance = Vector2.Distance(touch1.position, touch2.position);
                
                if (Mathf.Approximately(initialDistance, 0))
                {
                    return;
                }

                var factor = (currentDistance / initialDistance) * touchScaleSpeed;

                ARManager.model.transform.localScale = initialScale * factor;
            }
        }
    }

    private void CheckForMove()
    {
        Vector2 input = ARManager.playerInput.actions["Move"].ReadValue<Vector2>();

        Vector3 moveDir = new Vector3(input.x, 0, input.y);

        moveDir = moveDir.x * Camera.main.transform.right + moveDir.z * Camera.main.transform.forward;
        moveDir.y = 0;
        
        ARManager.model.GetComponent<CharacterController>().Move(moveDir * Time.deltaTime * touchMoveSpeed);
    }
    
    private void CheckForRotate()
    {
        Vector2 input = ARManager.playerInput.actions["Rotate"].ReadValue<Vector2>();

        ARManager.model.transform.Rotate(Vector3.down * (input.x * touchRotateSpeed) * Time.deltaTime);
        ARManager.model.transform.Rotate(Vector3.right * (input.y * touchRotateSpeed) * Time.deltaTime);
    }
    
    
    bool IsPointOverUIObject(Vector2 pos)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return false;
        }

        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
