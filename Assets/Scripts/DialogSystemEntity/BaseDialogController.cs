using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDialogController : MonoBehaviour
{
    public event Action OnDialogueEnded;

    public bool DialogIsExist => _dialog != null;
    
    protected DialogSubSystem _dialogSubSystem = null;
    protected BaseDialogue _dialog = null;

    public virtual void Initialize(DialogSubSystem system)
    {
        _dialogSubSystem = system;
    }

    public virtual void SetDialog(BaseDialogue dialog) 
    { 
        _dialog = dialog; 
    }

    public virtual void ActivateDialog() { }

    protected virtual void ProcessTheEndOfTheDialog() { }
    protected virtual void DeactivateDialog() { }

    public virtual void Clear()
    {
        _dialogSubSystem = null;
    }
}
