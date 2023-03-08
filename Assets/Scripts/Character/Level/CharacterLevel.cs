using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterLevel
{
    int Experience { get; }
    int Level { get; }
    int ProficiencyBonus { get; }
}

public class CharacterLevel : ICharacterLevel
{
    [SerializeField] private static LevelTable _levelTable;

    private int _experience;

    private int _level;

    private int _proficiencyBonus;


    public int Experience => _experience;
    public int Level => _level;
    public int ProficiencyBonus => _proficiencyBonus;

    private void CalcuateProficiencyBonus()
    {
        //бм: 1-5 +2, 6-10 +3, 11-15 +4, 16-20 +5, 21-25 +6, 26-30 +7 Пока оставлю условиями, но хорошо бы привести к формуле
        if (Level < 6)
            _proficiencyBonus = 2;
        else if (Level > 5 && Level < 11)
            _proficiencyBonus = 3;
        else if (Level > 10 && Level < 16)
            _proficiencyBonus = 4;
        else if (Level > 15 && Level < 21)
            _proficiencyBonus = 5;
        else if (Level > 20 && Level < 26)
            _proficiencyBonus = 6;
        else if (Level > 25 && Level < 31)
            _proficiencyBonus = 7;
    }
}




