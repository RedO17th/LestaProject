using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteCharacteristicUIController : MonoBehaviour
{
    [SerializeField] private ValueManipulatorButton[] _buttons = null;
    [SerializeField] private ValueView _valueView = null;

    public static event Action<int, CharacteristicType> OnCharacteristicValueChangeTryed;

    public void Start()
    {
        SubscribeButtons();
    }

    private void SubscribeButtons()
    {
        foreach (var button in _buttons)
        {
            button.Subscribe(HandleOnManipulatorClicked);
        }
    }


    private void HandleOnManipulatorClicked(OLDBaseButton sender)
    {
        var s = (ValueManipulatorButton)sender;
        var data = (CharacteristicsChangerButtonData)s.Data;

        int changeValue = data.ButtonType == ManipulatorButtonType.Increase ? 1 : -1;
        OnCharacteristicValueChangeTryed?.Invoke(changeValue, data.LinkedValueType);
    }
}
