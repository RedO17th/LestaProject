using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTriggerVolume : MonoBehaviour
{
    public event Action OnEnter;
    public event Action OnExit;

    protected Collider _trigger = null;

    private void Awake()
    {
        _trigger = GetComponent<Collider>();
    }

    public virtual void Enable()
    {
        _trigger.enabled = true;
    }

    private void OnTriggerEnter(Collider other) => ProcessingEnter(other);

    protected virtual void ProcessingEnter(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<GamePlayer>();

        if (player)
        {
            OnEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other) => ProcessingExit(other);

    protected virtual void ProcessingExit(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<GamePlayer>();

        if (player)
        {
            OnExit?.Invoke();
        }
    }

    public virtual void Disable()
    {
        _trigger.enabled = false;
    }
}
