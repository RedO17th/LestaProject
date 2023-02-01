using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxEnergy;
    [SerializeField] private int _maxExperience;

    [SerializeField] private int _health;
    [SerializeField] private int _energy;
    [SerializeField] private int _experience;

    [SerializeField] private int _level;

    public static TestPlayer Instance;

    public event Action<int> OnHealthChanged;
    public event Action<int> OnEnergyChanged;
    public event Action<int> OnExpChanged;
    public event Action<int> OnLevelChanged;

    public int MaxHealth => _maxHealth;
    public int MaxEnergy => _maxEnergy;
    public int MaxExperience => _maxExperience;

    private void Awake()
    {
        Instance = this;
    }

    private TestPlayer()
    {

    }
    

    public void ChangeHealth(int value)
    {
        ChangeParam(ref _health, value);
        OnHealthChanged?.Invoke(_health);
    }
    public void ChangeEnergy(int value)
    {
        ChangeParam(ref _energy, value);
        OnEnergyChanged?.Invoke(_energy);
    }
    public void ChangeExp(int value)
    {
        ChangeParam(ref _experience, value);
        OnExpChanged?.Invoke(_experience);
    }
    public void ChangeLevel(int value)
    {
        ChangeParam(ref _level, value);
        OnLevelChanged?.Invoke(_level);
    }

    public void ChangeParam(ref int param, int value)
    {
        param += value;
    }
  
}
