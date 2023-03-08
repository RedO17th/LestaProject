using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public interface ICharacteristic
{
    public CharacteristicName CharacteristicName { get; }
    public int Value { get; }

    public int Bonus { get; }

    //public void CalculateBonus();
}

[System.Serializable]
public class Characteristic : ICharacteristic
{
    public CharacteristicName CharacteristicName => _name;

    public int Value 
    {   
        get
        {
            return _value;
        }
        set 
        {
            if (value <= 0)
                value = 1;
            _value = value;
            //CalculateBonus();
        } 
    }

    public int Bonus => (Value - 10) / 2;

    [SerializeField] private int _value;
    [SerializeField] private CharacteristicName _name;

    //public void CalculateBonus()
    //{
    //    //Bonus = (Value - 10) / 2;
    //}

    public Characteristic(CharacteristicName characteristicName, int value)
    {
        _name = characteristicName;
        Value = value;
    }
}

//public class Characteristics
//{
//    public ICharacteristic STRENGTH =  new Characteristic(CharacteristicName.STRENGTH, 10);
//    public ICharacteristic DEXTERITY = new Characteristic(CharacteristicName.DEXTERITY, 10);
//    public ICharacteristic CONSTITUTION = new Characteristic(CharacteristicName.CONSTITUTION, 10);
//    public ICharacteristic INTELLIGENCE = new Characteristic(CharacteristicName.INTELLIGENCE, 10);
//    public ICharacteristic WISDOM = new Characteristic(CharacteristicName.WISDOM, 10);
//    public ICharacteristic CHARISMA = new Characteristic(CharacteristicName.CHARISMA, 10);
//}




public interface ICharacter
{
    string Name { get; }


    ICharacterClass Class { get; } //В класс нужно вшить основную характеристику, кость хитов, спасброски

    CharacteristicName ClassFocus { get; } //Получается из класса

    Dice HPDice { get; } //Получается из класса

    CharacteristicName[] SavingThrows { get; }
    //Спасброски
    // Название характеристики, отметка спаса           -   отметку спаса можно вшить прямо в характеристику, тогда не нужен будет отдельный блок спасов

    WeaponType[] WeaponPossession { get; }


    int Level { get; }

    int Experience { get; } //Опыт можно зашить в уровень

    int ProficiencyBonus { get; } //Получается из уровня, но на него могут повлиять эффекты

    //Спасы от смерти
    
    //КД
    
    //int Initiative { get; } //Получается из ловкости, но на неё влияют эффекты 

    //int PassivePerseption { get; } // 10 + бонус мудрости + бонус от прокачки навыка внимательности


    int SpellSaveDifficulty { get; } // 8 + БМ + осн хар + ?эффекты

    int SpellAttackBonus { get; } // осн хар + БМ + ?эффекты


    int MaxHealth { get; } //Меняется при лвлапе, при изменении телосложения, эффектом
    int Health { get; } //Меняется в бою и вне боя
    //int TemporaryHealth { get; } //?


    // Характеристики
    public ICharacteristic STRENGTH         { get; }
    public ICharacteristic DEXTERITY        { get; }
    public ICharacteristic CONSTITUTION     { get; }
    public ICharacteristic INTELLIGENCE     { get; }
    public ICharacteristic WISDOM           { get; }
    public ICharacteristic CHARISMA         { get; }


    //Инвентарь экипировки
    //  Экипировка
    //      Шлем
    //      Доспехи
    //      Перчатки
    //      Штаны
    //      Обувь
    //  Импланты х5
    //  Оружие х2
    

    //Инвентарь


    //Список эффектов
    

    //Умения

    //Способности



    //Пул расходников

    //Пул способностей

    //Ресурсы

}


[System.Serializable]
public class Character : MonoBehaviour //ICharacterы
{
    //public string Name { get; set; }
    //public ICharacterClass Class { get; private set; }


    //public ICharacteristic STRENGTH     { get; private set; } = new Characteristic(CharacteristicName.STRENGTH, 10);
    //public ICharacteristic DEXTERITY    { get; private set; } = new Characteristic(CharacteristicName.DEXTERITY, 10);
    //public ICharacteristic CONSTITUTION { get; private set; } = new Characteristic(CharacteristicName.CONSTITUTION, 10);
    //public ICharacteristic INTELLIGENCE { get; private set; } = new Characteristic(CharacteristicName.INTELLIGENCE, 10);
    //public ICharacteristic WISDOM       { get; private set; } = new Characteristic(CharacteristicName.WISDOM, 10);
    //public ICharacteristic CHARISMA     { get; private set; } = new Characteristic(CharacteristicName.CHARISMA, 10);


}



[CreateAssetMenu(fileName = "CharacterSO", menuName = "Data/Create New CharacterSO")]
public class CharacterSO : ScriptableObject//, ICharacter
{
    [SerializeField] private string _name;

    [SerializeField] private CharacterClass _class;

    [Space]
    [SerializeField] private LevelTable _levelTable;

    [SerializeField] private int _experience = 0;

    [SerializeField] private int _level = 1;

    [SerializeField] private int _proficiencyBonus = 2;

    [Space]
    [SerializeField] private Characteristic[] _chatacteristics = new Characteristic[6];
    public ICharacteristic[] Characteristics => _chatacteristics;

    [Space]
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;


    public string Name => _name;

    public ICharacterClass Class => _class;
    public string ClassName => _class.ClassName;
    public CharacteristicName ClassFocus => _class.ClassFocus;
    public Dice HPDice => _class.HPDice;
    public CharacteristicName[] SavingThrows => _class.SavingThrows;
    public WeaponType[] WeaponPossession => _class.WeaponPossession;


    public int Level => _level;
    public int Experience => _experience;
    public int ProficiencyBonus => _proficiencyBonus;

    public LevelTableString CurrentLevelTableString => _levelTable.LevelTableStrings[_level - 1];


    public ICharacteristic STRENGTH => GetCharacteristicByName(CharacteristicName.STRENGTH);
    public ICharacteristic DEXTERITY => GetCharacteristicByName(CharacteristicName.DEXTERITY);
    public ICharacteristic CONSTITUTION => GetCharacteristicByName(CharacteristicName.CONSTITUTION);
    public ICharacteristic INTELLIGENCE => GetCharacteristicByName(CharacteristicName.INTELLIGENCE);
    public ICharacteristic WISDOM => GetCharacteristicByName(CharacteristicName.WISDOM);
    public ICharacteristic CHARISMA => GetCharacteristicByName(CharacteristicName.CHARISMA);


    public int PassivePerseption => GetPassivePerseption();


    private int GetPassivePerseption()
    {
        int result = 10;

        result += WISDOM.Bonus;

        return result;
    }

    public int SetStartHealth()
    {
        string hpDiceString = _class.HPDice.ToString();
        string[] hpDiceStrings = hpDiceString.Split('D');

        int result = 0;
        result = Int32.Parse(hpDiceStrings[hpDiceStrings.Length]);

        result += CONSTITUTION.Bonus;
        return result;
    }

    public Characteristic GetCharacteristicByName(CharacteristicName characteristicName)
    {
        foreach (var characteristic in _chatacteristics)
        {
            if (characteristicName == characteristic.CharacteristicName)
                return characteristic;
        }
        return null;
    }

    public void IncreaseExperience(int valueExp)
    {
        if (valueExp <= 0)
            return;

        _experience += valueExp;

        if(CheckLevelUp())
        {
            LevelUp();
        }
    }

    public bool CheckLevelUp()
    {
        return (_experience >= CurrentLevelTableString.ExperienceBorder);
    }

    public void LevelUp()
    {
        _level++;

        UpdateProficiencyBonus();

        //+2 очка спелов
        //+2 очка навыков
        //if(_level % 3 == 0) + очко характеристики

        //+ хп за лвл
        
    }

    public void UpdateProficiencyBonus()
    {
         _proficiencyBonus = CurrentLevelTableString.ProficiencyBonus;
    }
}