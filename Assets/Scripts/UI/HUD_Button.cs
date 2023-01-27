using System;
using static HUD_Button;

public class HUD_Button : BaseButton
{
    public delegate void ClickListenerDeleagte();

    public void Initialize(ClickListenerDeleagte listener)
    {
        onClick.AddListener(delegate { listener(); });
    }
}
