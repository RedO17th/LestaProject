using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

//[ForMe] Может быть сделать еще промежуточную абстракцию между
//EncounterWithDialog и Dog в виде какого_нибудь "помощника"...

//Перевести ли данную сущность в интерфейс?

public class BasePlayerAssistant : EncounterWithDialog { }

public class Dog : BasePlayerAssistant
{
    //Test
    protected BaseInteractionController _interactionHandler = null;

    private BaseDialogController _dialogController = null;
    private DialogSubSystem _dialogSubSystem = null;

    protected override void Awake()
    {
        _interactionHandler = new BaseInteractionController(this);

        _dialogSubSystem = ProjectSystem.Instance.GetSubSystemByType(typeof(DialogSubSystem)) as DialogSubSystem;
        
        _dialogController = GetComponent<BaseDialogController>();
        _dialogController.Initialize(_dialogSubSystem);
    }

    private void OnEnable()
    {
        PrepareTriggerVolume();
    }
    private void OnDisable()
    {
        ClearTriggerVolume();
    }

    public override void InitializeDialog(string dialogName)
    {
        var dialog = _dialogSubSystem.GetDialogueByName(dialogName);
        _dialogController.SetDialog(dialog);

        Debug.Log($"Dog.InitializeDialog");
    }

    public override void Hint() => base.Hint();
    public override void Activate() => base.Activate();

    public override void Interact()
    {
        Debug.Log($"Dog.Interact");

        _pointer.Disable();

        //_interactionHandler.Interact();

        _dialogController.ActivateDialog();
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }

    //[Test]
    //private IEnumerator DialogTimer()
    //{
    //    yield return new WaitForSeconds(3f);

    //    if (_task != null)
    //    {
    //        var context = new TaskContext();
    //            context.SetCommand(TaskCommand.Complete);
    //            context.SetID(_task.IDName);

    //        ProjectBus.Instance.SendSignalByContext(context);
    //    }
    //}
}


