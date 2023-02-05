public class ClipboardScreenNavigationUIController : PlayerMenuNavigationUIController
{
    protected override void LeftArrowButtonClickListener()
    {
        EventSystem.InvokeOnAbilitiesScreenCalled();
    }

    protected override void RightArrowButtonClickListener()
    {
        EventSystem.InvokeOnInventoryScreenCalled();
    }
}
