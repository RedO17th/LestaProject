using UnityEngine;

[CreateAssetMenu(fileName = "CharacterCreationSettingsContainer", menuName = "ScriptableObjects/Container/CharacterCreationSettingsContainer")]
public class CharacterCreationSettingsContainer : BaseDataContainer
{
    public int StartCharacteristicsDistributionPoints = 10;

    public int MinCharacteristicsDistributionPoints = 0;

    public int StartCharacteristicValue = 10;

    public int MinCharacteristicValue = 1;

    public int MaxCharacteristicValue = 20;

    public int ValuesChangeStep = 1;

    public int SkillsDistributionPoints = 3;
}