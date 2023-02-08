using System;
using static UISubSystem;

public class EventSystem
{
    public class UIEvents
    {
        public static event Action<ScreenID> OnScreenCalled;
        public static event Action OnPlayerMenuExit;
        public static event Action OnPauseMenuCalled;
        public static event Action OnDialogueMenuCalled;
        public static event Action OnExitFromDialogueMenuCalled;
        public static event Action OnSaveCalled;
        public static event Action OnLoadCalled;
        public static event Action OnExitCalled;

        public static void InvokeOnPlayerMenuExit() => OnPlayerMenuExit?.Invoke();
        public static void InvokeOnPauseMenuCalled() => OnPauseMenuCalled?.Invoke();
        public static void InvokeOnScreenCalled(ScreenID ID) => OnScreenCalled?.Invoke(ID);
        public static void InvokeOnSaveCalled() => OnSaveCalled?.Invoke();
        public static void InvokeOnLoadCalled() => OnLoadCalled?.Invoke();
        public static void InvokeOnExitCalled() => OnExitCalled?.Invoke();
        public static void InvokeOnDialogueMenuCalled() => OnDialogueMenuCalled?.Invoke();
        public static void InvokeOnExitFromDialogueMenuCalled() => OnExitFromDialogueMenuCalled?.Invoke();
    }
 
    public static event Action OnPauseCalled;
    public static event Action OnResumeCalled;
    
    public static void InvokeOnResumeCalled() => OnResumeCalled?.Invoke();
    public static void InvokeOnPauseCalled() => OnPauseCalled?.Invoke();
}
