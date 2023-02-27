using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolumeByPlayer : BaseTriggerVolume
{
    public event Action<BasePlayer> OnEnter;
    public event Action<BasePlayer> OnExit;

    protected override void ProcessingEnter(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<BasePlayer>();

        if (player)
        {
            OnEnter?.Invoke(player);
        }
    }

    protected override void ProcessingExit(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<BasePlayer>();

        if (player)
        {
            OnExit?.Invoke(player);
        }
    }
}
