public class HUD_QuickAccess_Button : BaseButton
{
    public delegate void QuickAccessClickListenerDelegate(QuickAccessButtonID buttonID);

    public void Initialize(QuickAccessClickListenerDelegate listener, QuickAccessButtonID buttonID)
    {
        this.onClick.AddListener(delegate { listener(buttonID); });
    }
}
