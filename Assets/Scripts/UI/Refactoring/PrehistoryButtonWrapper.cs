using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PrehistoryButtonWrapper : BaseToggledButtonWrapper, ICallPopUp,
    IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Sprite _activeFrame;
    [SerializeField] private Sprite _inactiveFrame;

    [SerializeField] private Sprite _activeBackground;
    [SerializeField] private Sprite _inactiveBackground;

    [SerializeField] private Sprite _activePortrait;
    [SerializeField] private Sprite _inactivePortrait;

    [SerializeField] private PopUpContentContainer _popUpContent = null;

    private Image _frame = null;
    private Image _background = null;
    private Image _portrait = null;

    public void CallHidePopUp(PointerEventData eventData)
    {
        EventSystem.UIEvents.InvokeOnPopUpHideCalled(this, eventData, _popUpContent);
    }

    public void CallShowPopUp(PointerEventData eventData)
    {
        EventSystem.UIEvents.InvokeOnPopUpShowCalled(this, eventData, _popUpContent);
    }

    public override void Initialize()
    {
        base.Initialize();
        _frame = transform.Find("Frame").gameObject.GetComponent<Image>();
        _background = transform.Find("Background").gameObject.GetComponent<Image>();
        _portrait = transform.Find("Portrait").gameObject.GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CallShowPopUp(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CallHidePopUp(eventData);
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