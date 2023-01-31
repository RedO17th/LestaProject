using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogController : BaseDialogController
{
    private TextAsset _dialog = null;

    public override void Initialize(DialogSubSystem system)
    {
        base.Initialize(system);
    }

    public override void SetDialog(TextAsset dialog)
    {
        _dialog = dialog;
    }

    public override void ActivateDialog()
    {
        _dialogSubSystem.StartNewDialog(_dialog);
    }

    public override void Clear()
    {
        base.Clear();
    }
}