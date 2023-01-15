using UnityEngine;

public enum CheckMode
{
    None = -1,
    Characteristics,
    Skill
}

public class DiceTwentySubSystem : BaseSubSystem
{
    [Header("Characteristics")]
    [SerializeField] private int _subtractKoef = 10;
    [SerializeField] private int _divideKoef = 2;

    [Header("Skills")]
    [SerializeField] private int _baseSkillBonus = 2;
    [SerializeField] private int _skillBonusStep = 4;

    [Header("Dice")]
    [SerializeField] private int _diceMax = 20;

    private CharacteristicsContainer _characteristics = null;
    private SkillsContainer _skills = null;
    private PlayerDataContainer _playerData = null;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);
    }

    public override void Prepare()
    {
        var settingsSystem = _projectSystem.GetSubSystemByType(typeof(SettingsSubSystem)) as SettingsSubSystem;

        _characteristics = settingsSystem?.GetDataContainerByType(typeof(CharacteristicsContainer)) as CharacteristicsContainer;
        _skills = settingsSystem?.GetDataContainerByType(typeof(SkillsContainer)) as SkillsContainer;
        _playerData = settingsSystem?.GetDataContainerByType(typeof(PlayerDataContainer)) as PlayerDataContainer;
    }

    #region Characteristics part
    public BaseCharacteristic GetCharacteristicByType(CharacterisicType type)
    {
        return _characteristics.GetCharacteristicByType(type);
    }

    public bool Check(CharacterisicType characterisic, int difficult)
    {

        if (DiceRoll() + GetCharacteristicModificator(characterisic) >= difficult)
            return true;

        return false;
    }

    public int GetCharacteristicModificator(CharacterisicType characterisic)
    {
        var value = GetCharacteristicByType(characterisic).Value;

        int modificator = (value - _subtractKoef) / _divideKoef;

        if (value < _subtractKoef) //поправка дл€ отрицательных модификаторов
        {
            modificator += (value - _subtractKoef) % _divideKoef;
        }

        return modificator;
    }
    #endregion

    #region Skills part
    public BaseSkill GetSkillByType(SkillType type)
    {
        return _skills.GetSkillByType(type);
    }

    public bool Check(SkillType skill, int difficult)
    {
        if (DiceRoll() + GetSkillModificator(skill) >= difficult)
            return true;

        return false;
    }

    private int GetSkillModificator(SkillType type)
    {
        var skill = GetSkillByType(type);

        int modificator = GetSkillBonus(skill) + GetCharacteristicModificator(skill.CharacterisicType);

        return modificator;
    }

    private int GetSkillBonus(BaseSkill skill)
    {
        if (skill.IsLearn == false)
            return 0;

        int level = _playerData.Level;

        int skillBonus = (level - 1) / _skillBonusStep + _baseSkillBonus;

        return skillBonus;
    }
    #endregion

    private int DiceRoll()
    {
        int rollValue = Random.Range(0, 20) + 1;

        Debug.Log(rollValue);

        return rollValue;
    }
}
