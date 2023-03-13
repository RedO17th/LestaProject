using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacteristicsChoiceUIController : OLDBaseUIController
{
    //TODO: Вынести настройки в SO
    [Header("Настройки")]
    [SerializeField] private int _startCharacteristicsValue = 10;
    [SerializeField] private int _lowerValueBound = 1;
    [SerializeField] private int _higherValueBound = 20;
    [SerializeField] private int _distributionPoints = 10;
    [Space]

    [Header("Подконтрольные объекты")]
    [SerializeField] private ValueView _currentDistributionPointsView = null;
    [SerializeField] private CharacteristicValueView[] _valueViews = null;
    [SerializeField] private ValueManipulatorButton[] _buttons = null;
    [Space]

    private int _currentDistributionPoints = 0;

    private Dictionary<CharacteristicType, int> _currentCharacteristics;

    public void Start()
    {
        PrehistoryButtonsUIController.OnPrehistoryButtonClicked += Reset;
        Reset(PrehistoryEnum.Default);
        SubscribeButtons();
    }

    private void Reset(PrehistoryEnum prehistory)
    {
        InitializeCurrentCharacteristics();
        _currentDistributionPoints = _distributionPoints;
        SetDefaultViewValues();
    }

    private void InitializeCurrentCharacteristics()
    {
        _currentCharacteristics = new Dictionary<CharacteristicType, int>();
        foreach (CharacteristicType type in Enum.GetValues(typeof(CharacteristicType)))
        {
             _currentCharacteristics.Add(type, _startCharacteristicsValue);
        }
    }

    private void SetDefaultViewValues()
    {
        foreach(var valueView in _valueViews)
        {
            valueView.SetValue(_startCharacteristicsValue);
        }
        _currentDistributionPointsView.SetValue(_distributionPoints);
    }

    private void SubscribeButtons()
    {
        foreach (var button in _buttons)
        {
            button.Subscribe(HandleOnChangerButtonClicked);
        }
    }

    private void HandleOnChangerButtonClicked(OLDBaseButton sender)
    {
        var s = (ValueManipulatorButton)sender;
        var data = (CharacteristicsChangerButtonData)s.Data;

        if (TryChangeCharacteristicValue(data.LinkedValueType, data.ButtonType))
        {
            foreach(CharacteristicValueView v in _valueViews)
            {
                if (v.Type.Equals(data.LinkedValueType))
                {
                    v.SetValue(_currentCharacteristics[data.LinkedValueType]);
                    _currentDistributionPointsView.SetValue(_currentDistributionPoints);
                }
            }
        }
    }


    private bool TryChangeCharacteristicValue(CharacteristicType valueType, ManipulatorButtonType changeType)
    {
        bool isSuccsessful = false;
        int value = 0;
        if (_currentCharacteristics.TryGetValue(valueType, out value))
        {
            switch (changeType)
            {
                case ManipulatorButtonType.Increase:
                    value += 1;
                    if (value < _higherValueBound + 1 && _currentDistributionPoints > 0)
                    {
                        _currentDistributionPoints -= 1;
                        isSuccsessful = true;
                    }
                    break;

                case ManipulatorButtonType.Decrease:
                    value -= 1;
                    if (value > _lowerValueBound - 1)
                    {
                        _currentDistributionPoints += 1;
                        isSuccsessful = true;
                    }
                    break;
            }
            if (isSuccsessful)
            {
                _currentCharacteristics[valueType] = value;  
            }
        }

        return isSuccsessful;
    }
}

