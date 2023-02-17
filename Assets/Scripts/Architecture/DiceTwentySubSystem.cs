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

    [Header("For tests")]
    [SerializeField] private int _difficult = 10;
    [SerializeField] private CheckMode _checkMode = CheckMode.None;
    [SerializeField] private CharacteristicType _characterisicType = CharacteristicType.None;
    [SerializeField] private SkillType _skillType = SkillType.None;

    private CharacteristicsContainer _characteristics = null;
    private SkillsContainer _skills = null;
    private PlayerDataContainer _playerData = null;

    public override void Prepare()
    {
        var settingsSystem = ProjectSystem.GetSubSystem<SettingsSubSystem>();

        _characteristics = settingsSystem?.GetDataContainerByType(typeof(CharacteristicsContainer)) as CharacteristicsContainer;
        _skills = settingsSystem?.GetDataContainerByType(typeof(SkillsContainer)) as SkillsContainer;
        _playerData = settingsSystem?.GetDataContainerByType(typeof(PlayerDataContainer)) as PlayerDataContainer;
    }

    #region Characteristics part
    public bool CheckByCharacteristicType(CharacteristicType characterisic, int difficult)
    {
        return (DiceRoller.D20() + GetCharacteristicModificator(characterisic)) >= difficult;
    }
    public bool CheckByCharacteristicName(string characteristicName, int difficult)
    {
        CharacteristicType type = _characteristics.GetCharacterisicTypeByName(characteristicName);
        return CheckByCharacteristicType(type, difficult);
    }

    private int GetCharacteristicModificator(CharacteristicType type)
    {
        var characteristic = _characteristics.GetCharacteristicByType(type);

        var value = characteristic.Value;

        int modificator = (value - _subtractKoef) / _divideKoef;

        if (value < _subtractKoef) //поправка для отрицательных модификаторов
        {
            modificator += (value - _subtractKoef) % _divideKoef;
        }

        return modificator;
    }
    #endregion

    #region Skills part
    public bool CheckBySkillType(SkillType skill, int difficult)
    {
        return (DiceRoller.D20() + GetSkillModificator(skill)) >= difficult;
    }
    public bool CheckBySkillName(string skillName, int difficult)
    {
        SkillType type = _skills.GetSkillTypeByName(skillName);
        return CheckBySkillType(type, difficult);
    }

    private int GetSkillModificator(SkillType type)
    {
        var skill = _skills.GetSkillByType(type);

        return GetSkillBonus(skill) + GetCharacteristicModificator(skill.CharacterisicType);
    }

    private int GetSkillBonus(BaseSkill skill)
    {
        if (skill.IsLearn == false)
            return 0;

        return (_playerData.Level - 1) / _skillBonusStep + _baseSkillBonus;
    }
    #endregion

    #region Test part
#if UNITY_EDITOR
    [ContextMenu("TestCheck")]
    private void TestCheck()
    {
        if (_checkMode == CheckMode.None)
        {
            Debug.LogError("Не выбран режим проверки");
            return;
        }

        if (_checkMode == CheckMode.Characteristics)
        {
            if (_characterisicType == CharacteristicType.None)
            {
                Debug.LogError("Не выбрана характеристика для проверки");
                return;
            }
            else
            {
                bool result = CheckByCharacteristicType(_characterisicType, _difficult);
                Debug.Log(result ? "Success" : "Failure");
            }
        }
        if (_checkMode == CheckMode.Skill)
        {
            if (_skillType == SkillType.None)
            {
                Debug.LogError("Не выбран навык для проверки");
                return;
            }
            else
            {
                bool result = CheckBySkillType(_skillType, _difficult);
                Debug.Log(result ? "Success" : "Failure");
            }
        }
    }
#endif
    #endregion
}