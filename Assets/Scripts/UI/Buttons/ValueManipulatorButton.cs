using UnityEngine;

[RequireComponent(typeof(CharacteristicsChangerButtonData))]
public class ValueManipulatorButton : OLDBaseButton, IButtonWithData
{
    public IButtonData Data => _data;
    [SerializeField] private CharacteristicsChangerButtonData _data = null;

    public void Start()
    {
        _data = GetComponent<CharacteristicsChangerButtonData>();
    }
}
