using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogController : BaseDialogController
{
    private BaseDialog _dialog = null;

    public override void Initialize(DialogSubSystem system)
    {
        base.Initialize(system);
    }

    public override void SetDialog(BaseDialog dialog)
    {
        _dialog = dialog;
    }

    public override void ActivateDialog()
    {
        _dialog.Start();
    }

    public override void Clear()
    {
        base.Clear();
    }
}