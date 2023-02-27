using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSubSystem : BaseSubSystem
{
    [SerializeField] private List<BaseDataContainer> _dataContainers;

    public T GetDataContainer<T>() where T : BaseDataContainer
    {
        T container = null;

        foreach (var c in _dataContainers)
        {
            if (c is T)
            {
                container = c as T;
                break;
            }
        }

        return container;
    }
}
