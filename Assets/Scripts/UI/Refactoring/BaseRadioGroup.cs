using System;
using UnityEngine;


public class BaseRadioGroup : MonoBehaviour, IHaveButtons
{
    [SerializeField] protected BaseToggledButtonWrapper[] _radioButtons = null;

    public event Action<int> OnRadioSwitched = null;

    protected BaseToggledButtonWrapper _chosedButton = null;


    public virtual void OnEnable()
    {
        SubscribeToButtonsEvents();
    }


    public virtual void Start()
    {
        ResetRadioGroup();
    }

    protected virtual void ResetRadioGroup()
    {
        UpdateGroup(_radioButtons.GetValue(0) as BaseToggledButtonWrapper);
    }

    protected virtual void UpdateGroup(IButtonWrapper clickedButton)
    {
        if (_chosedButton == clickedButton)
        {
            return;
        }

        for (int i = 0; i < _radioButtons.Length; i++)
        {
            if (_radioButtons[i] == clickedButton)
            {
                _radioButtons[i].SetActive();
                OnRadioSwitched?.Invoke(i);
            }
            else
            {
                _radioButtons[i].SetInactive();
            }
        }
    }

    public void OnDisable()
    {
        UnsubscribeToButtonsEvents();
    }

    public void SubscribeToButtonsEvents()
    {
        foreach (var button in _radioButtons)
        {
            button.OnButtonClicked += UpdateGroup;
        }
    }

    public void UnsubscribeToButtonsEvents()
    {
        foreach (var button in _radioButtons)
        {
            button.OnButtonClicked -= UpdateGroup;
        }
    }
}