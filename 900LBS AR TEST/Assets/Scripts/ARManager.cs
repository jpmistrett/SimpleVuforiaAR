using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ARManager : MonoBehaviour
{
    public Slider scaleSlider;
    [HideInInspector] public float minScale, maxScale;
    [SerializeField] private List<Material> modelMaterials = new List<Material>();
    [HideInInspector] public GameObject model;
    [HideInInspector] public PlayerInput playerInput;

    private Vector3 initialScale, initialPosition;

    private int materialIndex = 0;

    void Start()
    {
        model = GameObject.FindWithTag("ARObject");

        initialScale = model.transform.localScale;

        minScale = model.transform.localScale.x;
        maxScale = minScale * scaleSlider.maxValue;

        scaleSlider.minValue = minScale;
        scaleSlider.maxValue = maxScale;

        scaleSlider.value = minScale;

        playerInput = model.GetComponent<PlayerInput>();
    }

    public void ChangeModelMaterial()
    {
        materialIndex++;

        if (materialIndex >= modelMaterials.Count)
        {
            materialIndex = 0;
        }

        model.GetComponent<Renderer>().material = modelMaterials[materialIndex];
    }

    public void ChangeModelScale(float scale)
    {
        model.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void ResetARObject()
    {
        //reset scale, color and rotation. Excluded position for a better AR user experience
        model.transform.rotation = new Quaternion(0,0,0,0);

        materialIndex = 0;
        model.GetComponent<Renderer>().material = modelMaterials[materialIndex];

        model.transform.localScale = initialScale;
        scaleSlider.value = minScale;
    }

    public void SetInitialPosition()
    {
        initialPosition = model.transform.position;
    }
}
