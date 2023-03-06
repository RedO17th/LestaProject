using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PrehistoryButtonData))]
public class OLDPrehistoryButton : OLDBaseButton, IButtonWithData, IToggledButton
{
    public IButtonData Data => _data;
    [SerializeField] private PrehistoryButtonData _data = null;

    public void Initialize()
    {
        _data = GetComponent<PrehistoryButtonData>();
        SetInactive();
    }

    public void SetActive()
    {
        _data.FrameImage.sprite = _data.ActiveFrameSprite;
        _data.PortraitImage.sprite = _data.ActivePortraitSprite;
        _data.BackgroundImage.sprite = _data.ActiveBackgroundSprite;
    }

    public void SetInactive()
    {
        _data.FrameImage.sprite = _data.InactiveFrameSprite;
        _data.PortraitImage.sprite = _data.InactivePortraitSprite;
        _data.BackgroundImage.sprite = _data.InactiveBackgroundSprite;
    }
}
