using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Characteristics", menuName = "ScriptableObjects/Container/Characteristics", order = 1)]
public class CharacteristicsContainer : BaseDataContainer
{
    [SerializeField] private List<BaseCharacteristic> _characteristics;

    public BaseCharacteristic GetCharacteristicByType(CharacterisicType type)
    {
        BaseCharacteristic characteristic = null;

        foreach (var ch in _characteristics)
        {
            if (ch.Type == type)
            {
                characteristic = ch;
                break;
            }
        }

        return characteristic;
    }
}
