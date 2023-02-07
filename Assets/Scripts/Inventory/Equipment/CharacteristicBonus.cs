[System.Serializable]
public class CharacteristicBonus
{
    public Characteristic Characteristic;
    public int Value;
}

[System.Serializable]
public enum Characteristic
{
    Strength,
    Agility,
    Wisdom
}