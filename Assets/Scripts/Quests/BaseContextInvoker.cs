using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInvokable
{
    void Invoke();
}

public abstract class BaseContextInvoker : MonoBehaviour, IInvokable
{
    public virtual void Invoke() => ProcessInvoke();

    protected virtual void ProcessInvoke() { }
}
