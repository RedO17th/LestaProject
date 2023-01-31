using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDialogController : MonoBehaviour
{
    protected DialogSubSystem _dialogSubSystem = null;

    public virtual void Initialize(DialogSubSystem system)
    {
        _dialogSubSystem = system;
    }

    public virtual void SetDialog(TextAsset dialog) { }

    public virtual void ActivateDialog() { }

    public virtual void Clear()
    {
        _dialogSubSystem = null;
    }
}
