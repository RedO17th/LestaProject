using UnityEngine;

public enum CharacterisicType { None = -1, Power, Sleight, Endurance, Intellect, Wisdom, Charisma }

[System.Serializable]
public class BaseCharacteristic
{
    [SerializeField] private CharacterisicType _type = CharacterisicType.None;

    [SerializeField] private string _name = string.Empty;

    [Range(0, 100)]
    [SerializeField] private int _value = 0;

    public CharacterisicType Type => _type;
    public string Name => _name;    
    public int Value => _value;
}
