using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface IClass
{ 

}

public class Class : IClass
{

}


public interface ICharacteristic
{
    public CharacteristicName CharacteristicName { get; }
    public int Value { get; }

    public int Bonus { get; }

    public void CalculateBonus();
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
            CalculateBonus();
        } 
    }

    public int Bonus { get; private set; }

    [SerializeField] private int _value;
    [SerializeField] private CharacteristicName _name;

    public void CalculateBonus()
    {
        Bonus = (Value - 10) / 2;
    }

    public Characteristic(CharacteristicName characteristicName, int value)
    {
        _name = characteristicName;
        Value = value;
    }
}

public class Characteristics
{
    public ICharacteristic STRENGTH =  new Characteristic(CharacteristicName.STRENGTH, 10);
    public ICharacteristic DEXTERITY = new Characteristic(CharacteristicName.DEXTERITY, 10);
    public ICharacteristic CONSTITUTION = new Characteristic(CharacteristicName.CONSTITUTION, 10);
    public ICharacteristic INTELLIGENCE = new Characteristic(CharacteristicName.INTELLIGENCE, 10);
    public ICharacteristic WISDOM = new Characteristic(CharacteristicName.WISDOM, 10);
    public ICharacteristic CHARISMA = new Characteristic(CharacteristicName.CHARISMA, 10);
}

public interface ICharacter
{
    string Name { get; }



    IClass Class { get; } //В класс нужно вшить основную характеристику, кость хитов, спасброски

    CharacteristicName ClassFocus { get; } //Получается из класса

    Dice HPDice { get; } //Получается из класса

    //Спасброски
    // Название характеристики, отметка спаса           -   отметку спаса можно вшить прямо в характеристику, тогда не нужен будет отдельный блок спасов



    int Level { get; }

    int Experience { get; } //Опыт можно зашить в уровень




    int ProficiencyBonus { get; } //Получается из уровня, но на него могут повлиять эффекты

    
    
    int Initiative { get; } //Получается из ловкости, но на неё влияют эффекты

    int PassivePerseption { get; } // 10 + бонус мудрости + бонус от прокачки навыка внимательности


    int SpellSaveDifficulty { get; } // 8 + БМ + осн хар + ?эффекты

    int SpellAttackBonus { get; } // осн хар + БМ + ?эффекты


    int MaxHealth { get; } //Меняется при лвлапе, при изменении телосложения, эффектом
    int Health { get; } //Меняется в бою и вне боя
    int TemporaryHealth { get; } //?


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
public class Character : MonoBehaviour //ICharacter
{
    public string Name { get; set; }
    public IClass Class { get; private set; }


    public ICharacteristic STRENGTH     { get; private set; } = new Characteristic(CharacteristicName.STRENGTH, 10);
    public ICharacteristic DEXTERITY    { get; private set; } = new Characteristic(CharacteristicName.DEXTERITY, 10);
    public ICharacteristic CONSTITUTION { get; private set; } = new Characteristic(CharacteristicName.CONSTITUTION, 10);
    public ICharacteristic INTELLIGENCE { get; private set; } = new Characteristic(CharacteristicName.INTELLIGENCE, 10);
    public ICharacteristic WISDOM       { get; private set; } = new Characteristic(CharacteristicName.WISDOM, 10);
    public ICharacteristic CHARISMA     { get; private set; } = new Characteristic(CharacteristicName.CHARISMA, 10);


}



[CreateAssetMenu(fileName = "CharacterSO", menuName = "Data/Create New CharacterSO")]
public class CharacteerSO : ScriptableObject// ICharacter
{
    [SerializeField] private string _name;

    //class

    //



    [SerializeField] private Characteristic _strength;
    public ICharacteristic STRENGTH => _strength;
}