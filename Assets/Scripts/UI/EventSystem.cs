using System;
using static UISubSystem;

public class EventSystem
{
    public class OLDUIEvents
    {
        public static event Action<IngameScreenID> OnScreenCalled;
        public static event Action OnPlayerMenuExit;
        public static event Action OnPauseMenuCalled;
        public static event Action OnDialogueMenuCalled;
        public static event Action OnExitFromDialogueMenuCalled;
        public static event Action OnSaveCalled;
        public static event Action OnLoadCalled;
        public static event Action OnExitCalled;

        public static void InvokeOnPlayerMenuExit() => OnPlayerMenuExit?.Invoke();
        public static void InvokeOnPauseMenuCalled() => OnPauseMenuCalled?.Invoke();
        public static void InvokeOnScreenCalled(IngameScreenID ID) => OnScreenCalled?.Invoke(ID);
        public static void InvokeOnSaveCalled() => OnSaveCalled?.Invoke();
        public static void InvokeOnLoadCalled() => OnLoadCalled?.Invoke();
        public static void InvokeOnExitCalled() => OnExitCalled?.Invoke();
        public static void InvokeOnDialogueMenuCalled() => OnDialogueMenuCalled?.Invoke();
        public static void InvokeOnExitFromDialogueMenuCalled() => OnExitFromDialogueMenuCalled?.Invoke();
    }


    public class UIEvents
    {
        //The transmitted argument is nameof(*BaseWindow child*)
        public static event Action<string, IWindow> OnScreenCalled;

        public static void InvokeOnWindowCalled(string windowTypeName, IWindow caller) => 
            OnScreenCalled?.Invoke(windowTypeName, caller);
    }

    public static event Action OnPauseCalled;
    public static event Action OnResumeCalled;
    
    public static void InvokeOnResumeCalled() => OnResumeCalled?.Invoke();
    public static void InvokeOnPauseCalled() => OnPauseCalled?.Invoke();
}
