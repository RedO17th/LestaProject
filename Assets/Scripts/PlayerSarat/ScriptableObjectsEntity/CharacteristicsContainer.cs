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

    public override List<string> GetAllNames()
    {
        List<string> names = new List<string>();

        for (int i = 0; i < _characteristics.Count; i++)
            names.Add(_characteristics[i].Name);

        return names;
    }
}
