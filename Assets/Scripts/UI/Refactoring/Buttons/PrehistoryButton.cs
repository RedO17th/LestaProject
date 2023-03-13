
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PrehistoryButton : REFBaseButton
{
    public ConcretePrehistory PrehistoryResourse { get; private set; } = null;
    private PrehistoryButtonCommonResorses _commonResourses = null;

    [SerializeField] private Image _frame = null;
    [SerializeField] private Image _background = null;
    [SerializeField] private Image _portrait = null;

    public void Initialize(UnityAction<REFBaseButton> listener, 
        ConcretePrehistory prehistory, PrehistoryButtonCommonResorses resorses)
    {
        base.Initialize(listener);
        PrehistoryResourse = prehistory;
        _commonResourses = resorses;
        _frame = transform.Find("Frame").gameObject.GetComponent<Image>();
        _background = transform.Find("Background").gameObject.GetComponent<Image>();
        _portrait = transform.Find("Portrait").gameObject.GetComponent<Image>();
        SetInactive();
    }

    public void SetActive()
    {
        _frame.sprite = _commonResourses.ActiveFrame;
        _background.sprite = _commonResourses.ActiveBackground;
        _portrait.sprite = PrehistoryResourse.ActivePortrait;
    }

    public void SetInactive()
    {
        _frame.sprite = _commonResourses.InactiveFrame;
        _background.sprite = _commonResourses.InactiveBackground;
        _portrait.sprite = PrehistoryResourse.InactivePortrait;
    }
}

