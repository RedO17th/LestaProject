using UnityEngine;

public enum ValueChangerButtonType
{
    Default = -1,
    Increase = 0,
    Decrease = 1
}

public class CharacteristicsChangerButtonData : MonoBehaviour, IButtonData
{
    [SerializeField] private ValueChangerButtonType _buttonType = ValueChangerButtonType.Default;
    [SerializeField] private CharacteristicType _linkedValueType = CharacteristicType.None;

    public ValueChangerButtonType ButtonType => _buttonType;

    public CharacteristicType LinkedValueType => _linkedValueType;
}


