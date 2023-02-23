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



    IClass Class { get; } //� ����� ����� ����� �������� ��������������, ����� �����, ����������

    CharacteristicName ClassFocus { get; } //���������� �� ������

    Dice HPDice { get; } //���������� �� ������

    //����������
    // �������� ��������������, ������� �����           -   ������� ����� ����� ����� ����� � ��������������, ����� �� ����� ����� ��������� ���� ������



    int Level { get; }

    int Experience { get; } //���� ����� ������ � �������




    int ProficiencyBonus { get; } //���������� �� ������, �� �� ���� ����� �������� �������

    
    
    int Initiative { get; } //���������� �� ��������, �� �� �� ������ �������

    int PassivePerseption { get; } // 10 + ����� �������� + ����� �� �������� ������ ��������������


    int SpellSaveDifficulty { get; } // 8 + �� + ��� ��� + ?�������

    int SpellAttackBonus { get; } // ��� ��� + �� + ?�������


    int MaxHealth { get; } //�������� ��� ������, ��� ��������� ������������, ��������
    int Health { get; } //�������� � ��� � ��� ���
    int TemporaryHealth { get; } //?


    // ��������������
    public ICharacteristic STRENGTH         { get; }
    public ICharacteristic DEXTERITY        { get; }
    public ICharacteristic CONSTITUTION     { get; }
    public ICharacteristic INTELLIGENCE     { get; }
    public ICharacteristic WISDOM           { get; }
    public ICharacteristic CHARISMA         { get; }


    //��������� ����������
    //  ����������
    //      ����
    //      �������
    //      ��������
    //      �����
    //      �����
    //  �������� �5
    //  ������ �2
    

    //���������


    //������ ��������
    

    //������

    //�����������



    //��� �����������

    //��� ������������

    //�������

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