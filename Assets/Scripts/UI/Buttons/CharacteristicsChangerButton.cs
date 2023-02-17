using UnityEngine;

[RequireComponent(typeof(CharacteristicsChangerButtonData))]
public class CharacteristicsChangerButton : BaseButton, IButtonWithData
{
    public IButtonData Data => _data;
    [SerializeField] private CharacteristicsChangerButtonData _data = null;

    public void Start()
    {
        _data = GetComponent<CharacteristicsChangerButtonData>();
    }
}
