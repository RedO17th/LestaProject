using System;
using UnityEngine;

public class PrehistoryButtonsUIController : BaseUIController
{
    public static event Action<PrehistoryEnum> OnPrehistoryButtonClicked;

    [SerializeField] private PrehistoryButton[] _buttons = null;

    public void Start()
    {
        foreach (var button in _buttons)
        {
            button.Initialize();
            button.Subscribe(HandleOnPrehistoryButtonClicked);
        }
        if (_buttons.Length > 0)
        {
            _buttons[0].SetActive();
        }
    }

    private void HandleOnPrehistoryButtonClicked(BaseButton sender)
    {
        foreach(var button in _buttons)
        {
            if (button == sender)
            {
                button.SetActive();
                OnPrehistoryButtonClicked?.Invoke(
                    (button.Data as PrehistoryButtonData).Prehistory);
            }
            else
            {
                button.SetInactive();
            }
        }
    }
}

