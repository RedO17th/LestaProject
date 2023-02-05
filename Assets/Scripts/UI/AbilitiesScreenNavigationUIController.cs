public class AbilitiesScreenNavigationUIController : PlayerMenuNavigationUIController
{
    protected override void LeftArrowButtonClickListener()
    {
        EventSystem.InvokeOnInventoryScreenCalled();
    }

    protected override void RightArrowButtonClickListener()
    {
        EventSystem.InvokeOnClipboardScreenCalled();
    }
}