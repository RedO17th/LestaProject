using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "CharacterClass", menuName = "Data/Create New CharacterClass")]
public class CharacterClass : ScriptableObject, ICharacterClass
{
    [SerializeField] private string _className;
    [SerializeField] private CharacteristicName _classFocus;
    [SerializeField] private Dice _hpDice;
    [SerializeField] private CharacteristicName[] _savingThrows;
    [SerializeField] private WeaponType[] _weaponPossession;

    public CharacteristicName ClassFocus => _classFocus;
    public Dice HPDice => _hpDice;
    public CharacteristicName[] SavingThrows => _savingThrows;
    public string ClassName => _className;

    public WeaponType[] WeaponPossession => _weaponPossession;
}
public interface ICharacterClass
{
    public string ClassName { get; }

    public CharacteristicName ClassFocus { get; }     //Основная характеристика

    public Dice HPDice { get; }                       //Кость хитов

    public CharacteristicName[] SavingThrows { get; } //Спасброски

    WeaponType[] WeaponPossession { get; }
}

public enum WeaponType
{
    Heavy,
    Lite
}