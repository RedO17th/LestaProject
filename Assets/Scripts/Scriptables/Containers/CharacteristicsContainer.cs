using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[Serializable]
[CreateAssetMenu(fileName = "Characteristics", menuName = "ScriptableObjects/Container/Characteristics", order = 1)]
public class CharacteristicsContainer : BaseDataContainer
{
    [SerializeField] private List<BaseCharacteristic> _characteristics;

    public BaseCharacteristic GetCharacteristicByType(CharacteristicType type)
    {
        return _characteristics.Find(x => x.Type.Equals(type));
    }

    public CharacteristicType GetCharacterisicTypeByName(string name)
    {
        return _characteristics.Find(x => x.Type.ToString().ToLower().Equals(name.ToLower())).Type;
    }
}
