﻿using System.Diagnostics.Contracts;
using UnityEngine;


public class BasePlayer : MonoBehaviour
{
    protected PlayerSubSystem _playerSystem = null;

    public HealthSign Health { get; } = new HealthSign(100);

    public EnergySign Energy { get; } = new EnergySign(150);
    
    //Level - заглушка для теста
    public Level Level { get; } = new Level();

    public virtual void Initialize(PlayerSubSystem system)
    {
        _playerSystem = system;
    }

    #region Health part

    //TODO: Если не пригодится, то убрать...
    public virtual void SetDamage() { }

    #endregion

    #region Wallet part
    //TODO: Если не пригодится, то убрать...

    public virtual void AddPoints(int points)
    {
        _playerSystem.AddPoints(points);
    }

    #endregion
}
