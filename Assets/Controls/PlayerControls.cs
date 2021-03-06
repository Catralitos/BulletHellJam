// GENERATED AUTOMATICALLY FROM 'Assets/Controls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""ControllerGameplay"",
            ""id"": ""62cc9997-61c8-4fd9-845a-0116347a3be3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""3e67139e-0b9a-4350-bec8-bc25401d685b"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""ecdd5417-3fc6-4664-a7d7-4ffe3f9f62a4"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Value"",
                    ""id"": ""4dd21cac-710e-485c-bc14-76fa09a3b72a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ce67c1ff-f9e4-4c66-a22e-0dfc20555855"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ff3aa82-4ea5-4a22-9a40-5a6b36680f8b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76274525-5376-4b26-bb10-2b8e7c4b6757"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7caad17b-e1cd-4fa3-8ec4-a19405d07798"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""KeyboardGameplay"",
            ""id"": ""1ae856ca-bdaa-4ea0-8f8d-e3bfe73a0f26"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""fa5337e4-a3c9-44f2-8da2-4f9b6c1744a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""a3fa7ce2-74c9-4f32-8ffe-31af2e29938a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""43652344-751f-4829-bf62-a38a612a9dfd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""a62b8299-5e5d-4dbf-ac6f-b704cff1a9a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ed457ccf-1ba0-4e3c-8069-33c876cabad0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e340b5c5-7ac9-462e-963e-2787dd9f36fa"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""aed259b8-042d-4886-a6a3-8758049c82cd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""06311723-6a6d-4add-94ea-544229954cb6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3f490150-370d-4954-8747-7173c69443ea"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""aa5eaf3d-43ab-453a-bb00-c5c0a0ad95db"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""009b177e-fbe5-4c00-8da6-050adfe0c63a"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7dc0cbb6-1cad-452b-aefd-1bab391c8ba6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ControllerGameplay
        m_ControllerGameplay = asset.FindActionMap("ControllerGameplay", throwIfNotFound: true);
        m_ControllerGameplay_Move = m_ControllerGameplay.FindAction("Move", throwIfNotFound: true);
        m_ControllerGameplay_Aim = m_ControllerGameplay.FindAction("Aim", throwIfNotFound: true);
        m_ControllerGameplay_Dash = m_ControllerGameplay.FindAction("Dash", throwIfNotFound: true);
        // KeyboardGameplay
        m_KeyboardGameplay = asset.FindActionMap("KeyboardGameplay", throwIfNotFound: true);
        m_KeyboardGameplay_Fire = m_KeyboardGameplay.FindAction("Fire", throwIfNotFound: true);
        m_KeyboardGameplay_Move = m_KeyboardGameplay.FindAction("Move", throwIfNotFound: true);
        m_KeyboardGameplay_Aim = m_KeyboardGameplay.FindAction("Aim", throwIfNotFound: true);
        m_KeyboardGameplay_Dash = m_KeyboardGameplay.FindAction("Dash", throwIfNotFound: true);
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

    // ControllerGameplay
    private readonly InputActionMap m_ControllerGameplay;
    private IControllerGameplayActions m_ControllerGameplayActionsCallbackInterface;
    private readonly InputAction m_ControllerGameplay_Move;
    private readonly InputAction m_ControllerGameplay_Aim;
    private readonly InputAction m_ControllerGameplay_Dash;
    public struct ControllerGameplayActions
    {
        private @PlayerControls m_Wrapper;
        public ControllerGameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_ControllerGameplay_Move;
        public InputAction @Aim => m_Wrapper.m_ControllerGameplay_Aim;
        public InputAction @Dash => m_Wrapper.m_ControllerGameplay_Dash;
        public InputActionMap Get() { return m_Wrapper.m_ControllerGameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerGameplayActions set) { return set.Get(); }
        public void SetCallbacks(IControllerGameplayActions instance)
        {
            if (m_Wrapper.m_ControllerGameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnAim;
                @Dash.started -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_ControllerGameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public ControllerGameplayActions @ControllerGameplay => new ControllerGameplayActions(this);

    // KeyboardGameplay
    private readonly InputActionMap m_KeyboardGameplay;
    private IKeyboardGameplayActions m_KeyboardGameplayActionsCallbackInterface;
    private readonly InputAction m_KeyboardGameplay_Fire;
    private readonly InputAction m_KeyboardGameplay_Move;
    private readonly InputAction m_KeyboardGameplay_Aim;
    private readonly InputAction m_KeyboardGameplay_Dash;
    public struct KeyboardGameplayActions
    {
        private @PlayerControls m_Wrapper;
        public KeyboardGameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_KeyboardGameplay_Fire;
        public InputAction @Move => m_Wrapper.m_KeyboardGameplay_Move;
        public InputAction @Aim => m_Wrapper.m_KeyboardGameplay_Aim;
        public InputAction @Dash => m_Wrapper.m_KeyboardGameplay_Dash;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardGameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardGameplayActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardGameplayActions instance)
        {
            if (m_Wrapper.m_KeyboardGameplayActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnFire;
                @Move.started -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnAim;
                @Dash.started -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_KeyboardGameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public KeyboardGameplayActions @KeyboardGameplay => new KeyboardGameplayActions(this);
    public interface IControllerGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
    public interface IKeyboardGameplayActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
}
