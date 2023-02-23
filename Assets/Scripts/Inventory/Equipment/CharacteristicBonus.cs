[System.Serializable]
public class CharacteristicBonus
{
    public CharacteristicName Characteristic;
    public int Value;
}

[System.Serializable]
public enum CharacteristicName
{
    STRENGTH,
    DEXTERITY,
    CONSTITUTION,
    INTELLIGENCE,
    WISDOM,
    CHARISMA
}