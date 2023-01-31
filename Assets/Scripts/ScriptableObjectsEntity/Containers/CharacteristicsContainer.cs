using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Characteristics", menuName = "ScriptableObjects/Container/Characteristics", order = 1)]
public class CharacteristicsContainer : BaseDataContainer
{
    [SerializeField] private List<BaseCharacteristic> _characteristics;

    public BaseCharacteristic GetCharacteristicByType(CharacterisicType type)
    {
        return _characteristics.Find(x => x.Type.Equals(type));
    }

    public CharacterisicType GetCharacterisicTypeByName(string name)
    {
        return _characteristics.Find(x => x.Type.ToString().ToLower().Equals(name.ToLower())).Type;
    }
}
