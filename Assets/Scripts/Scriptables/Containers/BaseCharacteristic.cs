using UnityEngine;

public enum CharacteristicType { None = -1, Power, Sleight, Endurance, Intellect, Wisdom, Charisma }

[System.Serializable]
public class BaseCharacteristic
{
    [SerializeField] private CharacteristicType _type = CharacteristicType.None;

    [SerializeField] private string _name = string.Empty;

    [Range(0, 100)]
    [SerializeField] private int _value = 0;

    public CharacteristicType Type => _type;
    public string Name => _name;    
    public int Value => _value;
}
