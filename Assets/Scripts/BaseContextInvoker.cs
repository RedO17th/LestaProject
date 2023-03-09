using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseContextInvoker : MonoBehaviour, IEncounter
{
    [SerializeField] protected string _name = string.Empty;

    public string Name => _name;

    protected virtual void Invoke() => ProcessInvoke();
    protected virtual void ProcessInvoke() { }
}