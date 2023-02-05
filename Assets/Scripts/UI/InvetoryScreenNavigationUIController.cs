using UnityEngine;

public class InvetoryScreenNavigationUIController : PlayerMenuNavigationUIController
{
    protected override void LeftArrowButtonClickListener()
    {
        EventSystem.InvokeOnClipboardScreenCalled();
    }
    
    protected override void RightArrowButtonClickListener()
    {
        EventSystem.InvokeOnAbilitiesScreenCalled();
        Debug.Log("RightArrowButtonClickListener");
    }
}
