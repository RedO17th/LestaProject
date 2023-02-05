using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseContextInvoker : BaseEncounter
{
    public virtual void Activate() { }

    protected virtual void Invoke() => ProcessInvoke();
    protected virtual void ProcessInvoke() { }
    protected virtual void Deactivate() { }
}
