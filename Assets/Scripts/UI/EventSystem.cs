using System;

public class EventSystem
{
    #region UI
    
    public static event Action OnClipboardScreenCalled;
    public static event Action OnInventoryScreenCalled;
    public static event Action OnAbilitiesScreenCalled;
    public static event Action OnPlayerMenuExit;
    

    public static void InvokeOnPlayerMenuExit() => OnPlayerMenuExit?.Invoke();
    public static void InvokeOnClipboardScreenCalled() => OnClipboardScreenCalled?.Invoke();
    public static void InvokeOnInventoryScreenCalled() => OnInventoryScreenCalled?.Invoke();
    public static void InvokeOnAbilitiesScreenCalled() => OnAbilitiesScreenCalled?.Invoke();


    #endregion UI





}
