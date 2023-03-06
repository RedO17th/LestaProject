//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/NewInputSystem/MainInputComponent.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MainInputComponent : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInputComponent()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainInputComponent"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""089751f6-5490-4b31-9063-ef195a42261d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1ce568f1-7e77-43bf-943c-380f18459c40"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Value"",
                    ""id"": ""9a0f691d-13d4-44c1-a9a2-c5199067c3e4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""f75229e1-105b-47c6-80c7-a6df788e4a91"",
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
                    ""id"": ""e9fc7d52-fc11-4bf9-b236-c2642a1e9be3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8c67d9c6-87d9-41e8-b936-9c0153210e80"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a96b9457-99e9-4b2a-b3fe-054795ddff9d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5c6cb20a-863d-47ec-be9d-9dbc97934cdd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""210a67cc-5bdf-46dc-8019-69e46f25e718"",
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
                    ""id"": ""a71c3baa-c657-4a47-99da-3014bb5fbc09"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bac204ba-76a4-439b-8ad1-d3515a0e11f3"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""41bee537-83d6-4d41-b88c-98394f271a9e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""17c4c05c-f99e-4b50-95d6-ec12f4593e13"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ebacb880-684c-44d4-a315-d496ebba450b"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""QuickAccessToolbar"",
            ""id"": ""40943268-4181-4d73-96b6-e3621ea924c7"",
            ""actions"": [
                {
                    ""name"": ""Z"",
                    ""type"": ""Button"",
                    ""id"": ""7491bc7b-f3ee-4051-813c-29ef84a7c531"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""2552e980-c09d-4b85-b4b0-c3439231deec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""C"",
                    ""type"": ""Button"",
                    ""id"": ""51a9e726-ddb9-4978-8fcf-30e05fd5205e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""V"",
                    ""type"": ""Button"",
                    ""id"": ""6a854bec-7781-40ff-83c9-086784901779"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""4a63e278-04ce-4219-af60-a069de3ab2b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""N"",
                    ""type"": ""Button"",
                    ""id"": ""372df6a4-ea90-4407-b011-9142e38f38e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""M"",
                    ""type"": ""Button"",
                    ""id"": ""cc232785-738e-4588-a0e2-67215cc6c9f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""47232ff9-5b95-4cb7-81e4-f9a31eef8f12"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb55f132-c231-45c1-baa2-35bc560f08be"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f592b975-9219-4d3a-9f4e-32270b1a6290"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""C"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfce6a58-77f1-4dc2-8a96-a05586605ac1"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""V"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a966b11a-1b78-49dc-9c0f-c414b2594579"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4695045-4ab3-4f80-bbc1-703546f995a5"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""N"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08f67198-0686-4996-85c9-61d18109e5a1"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""M"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MouseAndKeyboard"",
            ""bindingGroup"": ""MouseAndKeyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        // QuickAccessToolbar
        m_QuickAccessToolbar = asset.FindActionMap("QuickAccessToolbar", throwIfNotFound: true);
        m_QuickAccessToolbar_Z = m_QuickAccessToolbar.FindAction("Z", throwIfNotFound: true);
        m_QuickAccessToolbar_X = m_QuickAccessToolbar.FindAction("X", throwIfNotFound: true);
        m_QuickAccessToolbar_C = m_QuickAccessToolbar.FindAction("C", throwIfNotFound: true);
        m_QuickAccessToolbar_V = m_QuickAccessToolbar.FindAction("V", throwIfNotFound: true);
        m_QuickAccessToolbar_B = m_QuickAccessToolbar.FindAction("B", throwIfNotFound: true);
        m_QuickAccessToolbar_N = m_QuickAccessToolbar.FindAction("N", throwIfNotFound: true);
        m_QuickAccessToolbar_M = m_QuickAccessToolbar.FindAction("M", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Run;
    public struct PlayerActions
    {
        private @MainInputComponent m_Wrapper;
        public PlayerActions(@MainInputComponent wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // QuickAccessToolbar
    private readonly InputActionMap m_QuickAccessToolbar;
    private IQuickAccessToolbarActions m_QuickAccessToolbarActionsCallbackInterface;
    private readonly InputAction m_QuickAccessToolbar_Z;
    private readonly InputAction m_QuickAccessToolbar_X;
    private readonly InputAction m_QuickAccessToolbar_C;
    private readonly InputAction m_QuickAccessToolbar_V;
    private readonly InputAction m_QuickAccessToolbar_B;
    private readonly InputAction m_QuickAccessToolbar_N;
    private readonly InputAction m_QuickAccessToolbar_M;
    public struct QuickAccessToolbarActions
    {
        private @MainInputComponent m_Wrapper;
        public QuickAccessToolbarActions(@MainInputComponent wrapper) { m_Wrapper = wrapper; }
        public InputAction @Z => m_Wrapper.m_QuickAccessToolbar_Z;
        public InputAction @X => m_Wrapper.m_QuickAccessToolbar_X;
        public InputAction @C => m_Wrapper.m_QuickAccessToolbar_C;
        public InputAction @V => m_Wrapper.m_QuickAccessToolbar_V;
        public InputAction @B => m_Wrapper.m_QuickAccessToolbar_B;
        public InputAction @N => m_Wrapper.m_QuickAccessToolbar_N;
        public InputAction @M => m_Wrapper.m_QuickAccessToolbar_M;
        public InputActionMap Get() { return m_Wrapper.m_QuickAccessToolbar; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(QuickAccessToolbarActions set) { return set.Get(); }
        public void SetCallbacks(IQuickAccessToolbarActions instance)
        {
            if (m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface != null)
            {
                @Z.started -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnZ;
                @Z.performed -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnZ;
                @Z.canceled -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnZ;
                @X.started -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnX;
                @X.performed -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnX;
                @X.canceled -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnX;
                @C.started -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnC;
                @C.performed -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnC;
                @C.canceled -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnC;
                @V.started -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnV;
                @V.performed -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnV;
                @V.canceled -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnV;
                @B.started -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnB;
                @B.performed -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnB;
                @B.canceled -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnB;
                @N.started -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnN;
                @N.performed -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnN;
                @N.canceled -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnN;
                @M.started -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnM;
                @M.performed -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnM;
                @M.canceled -= m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface.OnM;
            }
            m_Wrapper.m_QuickAccessToolbarActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Z.started += instance.OnZ;
                @Z.performed += instance.OnZ;
                @Z.canceled += instance.OnZ;
                @X.started += instance.OnX;
                @X.performed += instance.OnX;
                @X.canceled += instance.OnX;
                @C.started += instance.OnC;
                @C.performed += instance.OnC;
                @C.canceled += instance.OnC;
                @V.started += instance.OnV;
                @V.performed += instance.OnV;
                @V.canceled += instance.OnV;
                @B.started += instance.OnB;
                @B.performed += instance.OnB;
                @B.canceled += instance.OnB;
                @N.started += instance.OnN;
                @N.performed += instance.OnN;
                @N.canceled += instance.OnN;
                @M.started += instance.OnM;
                @M.performed += instance.OnM;
                @M.canceled += instance.OnM;
            }
        }
    }
    public QuickAccessToolbarActions @QuickAccessToolbar => new QuickAccessToolbarActions(this);
    private int m_MouseAndKeyboardSchemeIndex = -1;
    public InputControlScheme MouseAndKeyboardScheme
    {
        get
        {
            if (m_MouseAndKeyboardSchemeIndex == -1) m_MouseAndKeyboardSchemeIndex = asset.FindControlSchemeIndex("MouseAndKeyboard");
            return asset.controlSchemes[m_MouseAndKeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
    public interface IQuickAccessToolbarActions
    {
        void OnZ(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnC(InputAction.CallbackContext context);
        void OnV(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
        void OnN(InputAction.CallbackContext context);
        void OnM(InputAction.CallbackContext context);
    }
}
