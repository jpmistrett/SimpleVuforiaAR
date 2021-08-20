// GENERATED AUTOMATICALLY FROM 'Assets/Resources/ARMoveControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ARMoveControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ARMoveControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ARMoveControls"",
    ""maps"": [
        {
            ""name"": ""ARControls"",
            ""id"": ""4c57c9e1-874d-4e84-972a-478dc9c5d3d2"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""bb81b98d-f444-4d9a-b8ad-70cb3cf4b15d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""a534d8bc-80dc-4130-bd07-c7c0a451dec4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""54797d32-9ae6-4299-945c-b7d4fa33dc89"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebeaf6fd-184a-43d6-a316-fb07927fc48f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ARControls
        m_ARControls = asset.FindActionMap("ARControls", throwIfNotFound: true);
        m_ARControls_Move = m_ARControls.FindAction("Move", throwIfNotFound: true);
        m_ARControls_Rotate = m_ARControls.FindAction("Rotate", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // ARControls
    private readonly InputActionMap m_ARControls;
    private IARControlsActions m_ARControlsActionsCallbackInterface;
    private readonly InputAction m_ARControls_Move;
    private readonly InputAction m_ARControls_Rotate;
    public struct ARControlsActions
    {
        private @ARMoveControls m_Wrapper;
        public ARControlsActions(@ARMoveControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_ARControls_Move;
        public InputAction @Rotate => m_Wrapper.m_ARControls_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_ARControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ARControlsActions set) { return set.Get(); }
        public void SetCallbacks(IARControlsActions instance)
        {
            if (m_Wrapper.m_ARControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ARControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ARControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ARControlsActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_ARControlsActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_ARControlsActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_ARControlsActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_ARControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public ARControlsActions @ARControls => new ARControlsActions(this);
    public interface IARControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
}
