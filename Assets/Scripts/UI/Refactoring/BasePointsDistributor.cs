using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.UIElements;
using System;
using TMPro;
using System.Linq;

public class BasePointsDistributor: MonoBehaviour
{
    //Типы полей захардкожены, в идеале использовать интерфейсы, но поля не сереализуются
    [SerializeField] protected BaseDistributionButtonsGroup[] _distributionGroups = null;

    [SerializeField] protected BaseNumericValueDisplay[] _valueGroupsDisplays = null;

    [SerializeField] protected BaseNumericValueDisplay _pointsToDistributeValueDisplay = null;

    [SerializeField] protected CharacterCreationSettingsContainer _settings = null;

    protected int[] _groupsValues = null;

    protected int _currentPointsToDistribute = 0;

    public virtual void OnEnable()
    {
        SubscribeToEvents();
    }

    public virtual void Start()
    {
        Reset();
    }


    public virtual void OnDisable()
    {
        UnsubscribeFromEvents();
    }


    protected virtual void SubscribeToEvents()
    {
        foreach (var group in _distributionGroups)
        {
            group.OnDecreseValueRequest += HandleOnDecreaseRequset;
            group.OnIncreseValueRequest += HandleOnIncreaseRequest;
        }
    }


    protected virtual void UnsubscribeFromEvents()
    {
        foreach (var group in _distributionGroups)
        {
            group.OnDecreseValueRequest -= HandleOnDecreaseRequset;
            group.OnIncreseValueRequest -= HandleOnIncreaseRequest;
        }
    }


    public virtual void Reset()
    {
        ResetValues();
        ResetDisplays();
    }


    protected virtual void ResetValues()
    {
        int valuesArrayLength = Math.Min(_distributionGroups.Length, _valueGroupsDisplays.Length);
        _groupsValues = new int[valuesArrayLength];
        for (int i = 0; i < valuesArrayLength; i++)
        {
            _groupsValues[i] = _settings.StartCharacteristicValue;
        }
        _currentPointsToDistribute = _settings.StartCharacteristicValue;
    }


    protected virtual void ResetDisplays()
    {
        _pointsToDistributeValueDisplay.ChangeDisplayedValue(_currentPointsToDistribute);

        for (int i = 0; i < _valueGroupsDisplays.Length; i++)
        {
            _valueGroupsDisplays[i].ChangeDisplayedValue(_groupsValues[i]);
        }
    }


    protected virtual void HandleOnDecreaseRequset(IDistributionGroup requester)
    {
        for (int i = 0; i < _distributionGroups.Length; i++)
        {
            if (_distributionGroups[i] == requester)
            {
                bool isInBoundaries = _groupsValues[i] - _settings.ValuesChangeStep >= _settings.MinCharacteristicValue;
                if (isInBoundaries)
                {
                    try
                    {
                        _groupsValues[i] -= _settings.ValuesChangeStep;
                        _valueGroupsDisplays[i].ChangeDisplayedValue(_groupsValues[i]);

                        _currentPointsToDistribute += _settings.ValuesChangeStep;
                        _pointsToDistributeValueDisplay.ChangeDisplayedValue(_currentPointsToDistribute);
                        break;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //Length of _distributionGroups must be equals to _valueGroupsDisplays length
                    }
                }
            }
        }
    }


    protected virtual void HandleOnIncreaseRequest(IDistributionGroup requester)
    {
        for (int i = 0; i < _distributionGroups.Length; i++)
        {
            if (_distributionGroups[i] == requester)
            {
                bool isInBoundaries = _groupsValues[i] + _settings.ValuesChangeStep <= _settings.MaxCharacteristicValue;
                bool isEnoughPoints = _currentPointsToDistribute - _settings.ValuesChangeStep >= _settings.MinCharacteristicsDistributionPoints;
                if (isInBoundaries && isEnoughPoints)
                {
                    try
                    {
                        _groupsValues[i] += _settings.ValuesChangeStep;
                        _valueGroupsDisplays[i].ChangeDisplayedValue(_groupsValues[i]);

                        _currentPointsToDistribute -= _settings.ValuesChangeStep;
                        _pointsToDistributeValueDisplay.ChangeDisplayedValue(_currentPointsToDistribute);
                        break;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //Length of _distributionGroups must be equals to _valueGroupsDisplays length
                    }
                }
            }
        }
    }
}