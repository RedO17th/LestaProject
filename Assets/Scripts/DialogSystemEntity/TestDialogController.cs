using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogController : BaseDialogController
{
    [SerializeField] TextAsset _story = null;

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
        _dialogSubSystem.StartNewDialog(_story);
    }

    public override void Clear()
    {
        base.Clear();
    }
}