using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolumeByPlayer : BaseTriggerVolume
{
    public event Action<GamePlayer> OnEnter;
    public event Action<GamePlayer> OnExit;

    protected override void ProcessingEnter(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<GamePlayer>();

        if (player)
        {
            OnEnter?.Invoke(player);
        }
    }

    protected override void ProcessingExit(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<GamePlayer>();

        if (player)
        {
            OnExit?.Invoke(player);
        }
    }
}
