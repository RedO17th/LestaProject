using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFunctionalVolume : IActivatable
{
    //Энкаунтер, который работает сам по себе.
    //Все, что нужно - это только включить его.
    //Он не реализует IEncounter...
}

public class FunctionalTriggerVolume : BaseEncounter, IInteractable, IFunctionalVolume
{
    protected Collider _trigger = null;

    protected virtual void Awake() 
    {
        _trigger = GetComponent<Collider>();
    }

    protected virtual void Start() { }

    public virtual void Activate() 
    {
        _trigger.enabled = true;
    }


    private void OnTriggerEnter(Collider other) => ProcessingEnter(other);
    protected virtual void ProcessingEnter(Collider other) { }

    public virtual void Interact() { }

    private void OnTriggerExit(Collider other) => ProcessingExit(other);
    protected virtual void ProcessingExit(Collider other) { }

    public virtual void Deactivate() 
    {
        _trigger.enabled = false;
    }
    protected virtual void Clear() { }
}
