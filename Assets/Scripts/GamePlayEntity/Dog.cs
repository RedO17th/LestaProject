using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialogable
{
    void InitializeDialogable(DialogSubSystem system);
    void SetDialog(BaseDialog dialog);
}

public interface ITalkable : IDialogable
{
    void Talk();
}

public class Dog : Encounter, ITalkable
{
    //ƒанный контроллер может быть разным, под каждый отдельный диалог -
    // - свой собственный
    private BaseDialogController _dialogController = null;

    protected override void Awake()
    {
        _dialogController = GetComponent<BaseDialogController>();
    }

    public void InitializeDialogable(DialogSubSystem system)
    {
        _dialogController.Initialize(system); 
    }
    public void SetDialog(BaseDialog dialog)
    {
        _dialogController.SetDialog(dialog);
    }


    public override void Activate()
    {
        base.Activate();
    }

    //ј взаимодействие может быть только каким-то одним форматом?
    public override void Interact()
    {
        Debug.Log($"Dog.Interact");

        _pointer.Disable();

        //_questLink.Complete();
        Talk();
    }

    public void Talk()
    {
        _dialogController.ActivateDialog();


    }

    public override void Deactivate()
    {
        base.Deactivate();
    }
}
