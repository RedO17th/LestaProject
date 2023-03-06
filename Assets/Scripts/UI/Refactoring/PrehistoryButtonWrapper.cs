using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PrehistoryButtonWrapper : BaseToggledButtonWrapper
{
    [SerializeField] private Sprite _activeFrame;
    [SerializeField] private Sprite _inactiveFrame;

    [SerializeField] private Sprite _activeBackground;
    [SerializeField] private Sprite _inactiveBackground;

    [SerializeField] private Sprite _activePortrait;
    [SerializeField] private Sprite _inactivePortrait;

    private Image _frame = null;
    private Image _background = null;
    private Image _portrait = null;

    public override void Initialize()
    {
        base.Initialize();
        _frame = transform.Find("Frame").gameObject.GetComponent<Image>();
        _background = transform.Find("Background").gameObject.GetComponent<Image>();
        _portrait = transform.Find("Portrait").gameObject.GetComponent<Image>();

        //ImageAlphaCutoff backgroundAlphaComponent = _background.gameObject.AddComponent(typeof(ImageAlphaCutoff)) as ImageAlphaCutoff;
        //backgroundAlphaComponent.AlphaLevel = 0.1f;

        //_button.targetGraphic = _background;
    }

    public override void SetActive()
    {
        _frame.sprite = _activeFrame;
        _background.sprite = _activeBackground;
        _portrait.sprite = _activePortrait;
    }

    public override void SetInactive()
    {
        _frame.sprite = _inactiveFrame;
        _background.sprite = _inactiveBackground;
        _portrait.sprite = _inactivePortrait;
    }
}