using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSubSystem : BaseSubSystem
{
    [SerializeField] private List<BaseDataContainer> _dataContainers;

    public BaseDataContainer GetDataContainerByType(Type type)
    {
        BaseDataContainer dataContainer = null;

        foreach (var data in _dataContainers)
        {
            if (data.GetType() == type)
            {
                dataContainer = data;
                break;
            }
        }

        return dataContainer;
    }
}
