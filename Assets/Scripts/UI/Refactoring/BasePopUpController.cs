using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public interface ICallPopUp
{
    void CallShowPopUp(PointerEventData eventData);
    void CallHidePopUp(PointerEventData eventData);
}


public class BasePopUpController : MonoBehaviour
{
    [SerializeField] private BasePopUp _commonPopUp = null;
    [SerializeField] private BaseOverlayPopUp _overlayPopUp = null;

    private BasePopUp _currentDisplayedPopUp = null;

    public virtual void OnEnable()
    {
        EventSystem.UIEvents.OnPopUpShowCalled += ShowPopUp;
        EventSystem.UIEvents.OnPopUpHideCalled += HidePopUp;

    }


    public virtual void ShowPopUp(ICallPopUp caller, PointerEventData eventData, PopUpContentContainer popUpContent)
    {
        if (_currentDisplayedPopUp != null)
        {
            HidePopUp(caller, eventData, popUpContent );
        }
        _currentDisplayedPopUp = _commonPopUp;

        RectTransform callerRectTransform = (caller as MonoBehaviour).GetComponent<RectTransform>();

        SetUpPopUp(popUpContent, callerRectTransform);

        _currentDisplayedPopUp.Show();
    }


    public virtual void HidePopUp(ICallPopUp caller, PointerEventData eventData, PopUpContentContainer popUpContent)
    {
        _currentDisplayedPopUp.Hide();
        _currentDisplayedPopUp = null;
    }


    public void SetUpPopUp(PopUpContentContainer popUpContent, RectTransform callerRectTransform)
    {
        _currentDisplayedPopUp.SetHeaderText(popUpContent.Header);
        _currentDisplayedPopUp.SetContentText(popUpContent.Content);
        Vector2 callerPosition = callerRectTransform.position;
        Vector2 upperLeftCorner = new Vector2(
            callerRectTransform.rect.width / 2 + callerPosition.x,
            callerRectTransform.rect.height / 2 - callerPosition.y);
        Debug.Log(upperLeftCorner);
        _currentDisplayedPopUp.SetPosition(callerPosition);
    }
}





public class BaseOverlayPopUp : BasePopUp
{
    [SerializeField] private CommonButtonWrapper _closeButton = null;
}
