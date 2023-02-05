using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IContextInvoker : IEncounter
{
    void Activate();
}

public abstract class BaseContextInvoker : MonoBehaviour, IContextInvoker
{
    [SerializeField] protected string _name = string.Empty;

    public string Name => _name;

    public virtual void Activate() { }

    protected virtual void Invoke() => ProcessInvoke();
    protected virtual void ProcessInvoke() { }
    protected virtual void Deactivate() { }
}
