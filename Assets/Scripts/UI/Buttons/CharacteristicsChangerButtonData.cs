using UnityEngine;

public enum ManipulatorButtonType
{
    Default = -1,
    Increase = 0,
    Decrease = 1
}

public class CharacteristicsChangerButtonData : MonoBehaviour, IButtonData
{
    [SerializeField] private ManipulatorButtonType _buttonType = ManipulatorButtonType.Default;
    [SerializeField] private CharacteristicType _linkedValueType = CharacteristicType.None;

    public ManipulatorButtonType ButtonType => _buttonType;

    public CharacteristicType LinkedValueType => _linkedValueType;
}


