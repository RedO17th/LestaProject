using System;

public class EventSystem
{
    #region UI
    
    public static event Action<string> OnScreenCalled;
    public static event Action OnPlayerMenuExit;
    
    
    public static void InvokeOnPlayerMenuExit() => OnPlayerMenuExit?.Invoke();
    public static void InvokeOnScreenCalled(string ID) => OnScreenCalled?.Invoke(ID);


    #endregion UI





}
