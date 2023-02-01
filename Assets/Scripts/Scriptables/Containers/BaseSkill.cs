using UnityEngine;

public enum SkillType
{
    None = -1,
    Acrobatics,
    Athletics,
    Conviction,
    Intimidation,
    Deception,
    Stealth,
    SleightOfHand,
    Alertness,
    Analysis,
    Hacking,
    Mechanics,
    Programming
}

[System.Serializable]
public class BaseSkill
{
    [SerializeField] private SkillType _type = SkillType.None;
    [SerializeField] private string _name = string.Empty;
    [SerializeField] private CharacterisicType _characterisicType = CharacterisicType.None;
    [SerializeField] private bool _isLearn = false;

    public SkillType Type => _type;
    public string Name => _name;
    public CharacterisicType CharacterisicType => _characterisicType;
    public bool IsLearn => _isLearn;
}
