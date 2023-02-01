using System;

public class HUD_Button : BaseButton
{
    public delegate void ClickListenerDeleagte();

    public void Initialize(ClickListenerDeleagte listener)
    {
        onClick.AddListener(delegate { listener(); });
    }
}
