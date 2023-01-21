using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWindow : MonoBehaviour
{
    protected UISubSystem _UISubSystem = null;

    public virtual void Initialize(UISubSystem system)
    {
        _UISubSystem = system;
    }
}
