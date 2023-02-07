using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestPlayer : MonoBehaviour
{
    private BasePlayer _player = null;

    private void Start()
    {
        var playerSubSystem = ProjectSystem.Instance.GetSubSystemByType(typeof(PlayerSubSystem)) as PlayerSubSystem;
        _player = playerSubSystem.Player;
    }

    public void ChangeHealth(int value)
    {
        _player.Health.CurrentValue += value;
    }
    public void ChangeEnergy(int value)
    {
        _player.Energy.CurrentValue += value;
    }
    public void ChangeExp(int value)
    {
        _player.Level.CurrentPoints += value;
    }
}
