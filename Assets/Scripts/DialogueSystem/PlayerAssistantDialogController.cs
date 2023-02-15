using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAssistantDialogController : BaseDialogController
{
    public override void ActivateDialog()
    {
        _dialogSubSystem.StartNewDialog(_dialog);
    }

    protected override void ProcessTheEndOfTheDialog()
    {
        _dialog = null;
    }

    protected override void DeactivateDialog() { }

    public override void Clear()
    {
        base.Clear();
    }
}