using System;
using UnityEngine;

public class PrehistoryButtonsUIController : OLDBaseUIController
{
    public static event Action<PrehistoryEnum> OnPrehistoryButtonClicked;

    [SerializeField] private OLDPrehistoryButton[] _buttons = null;

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

    private void HandleOnPrehistoryButtonClicked(OLDBaseButton sender)
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

