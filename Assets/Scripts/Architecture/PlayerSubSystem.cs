using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubSystem : BaseProjectSubSystem
{
    [SerializeField] private BasePlayer[] _players = null;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);

        InitializePlayers();
    }

    private void InitializePlayers()
    {
        foreach (var player in _players)
            player.Initialize(this);
    }
}
