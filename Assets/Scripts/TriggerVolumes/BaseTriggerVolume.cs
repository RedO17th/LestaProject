using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseVolume : MonoBehaviour 
{
    //Empty class - source
}

public interface IEnabable
{
    void Enable();
}
public interface IDisabable
{
    void Disable();
}
public interface ITriggerVolume : IEnabable, IDisabable { }

public abstract class BaseTriggerVolume : BaseVolume, ITriggerVolume
{
    protected Collider _trigger = null;

    protected virtual void Awake()
    {
        _trigger = GetComponent<Collider>();
    }

    public virtual void Enable()
    {
        _trigger.enabled = true;
    }

    private void OnTriggerEnter(Collider other) => ProcessingEnter(other);
    protected virtual void ProcessingEnter(Collider other) { }

    private void OnTriggerExit(Collider other) => ProcessingExit(other);
    protected virtual void ProcessingExit(Collider other) { }

    public virtual void Disable()
    {
        _trigger.enabled = false;
    }
}
