using UnityEngine;


public class CharacteristicValueView : ValueView
{
    [SerializeField] private CharacteristicType _type = CharacteristicType.None;
    public CharacteristicType Type => _type;
}
