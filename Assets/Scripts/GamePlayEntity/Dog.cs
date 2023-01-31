using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : EncounterWithDialog
{
    //Test
    protected BaseInteractionController _interactionHandler = null;

    protected override void Awake()
    {
        _interactionHandler = new BaseInteractionController(this);
    }

    private void OnEnable()
    {
        PrepareTriggerVolume();
    }
    private void OnDisable()
    {
        ClearTriggerVolume();
    }

    public override void InitializeDialog()
    {
        _dialog = "Some dialog";

        Debug.Log($"Dog.InitializeDialog: { _dialog } ");
    }

    public override void Hint() => base.Hint();
    public override void Activate() => base.Activate();

    public override void Interact()
    {
        Debug.Log($"Dog.Interact");

        _pointer.Disable();

        //_interactionHandler.Interact();
        if (_dialog != string.Empty)
            StartCoroutine(DialogTimer());
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }

    //[Test]
    private IEnumerator DialogTimer()
    {
        yield return new WaitForSeconds(3f);

        if (_task != null)
        {
            var context = new TaskContext();
                context.SetCommand(TaskCommand.Complete);
                context.SetID(_task.IDName);

            ProjectBus.Instance.SendSignalByContext(context);
        }
    }
}

//[ForMe]
//Общий контейнер в котором лежит тип DialogByQuestTask (DialogByTask) - 
//в нем указывается сам файл диалога и его idname, 
//по команде InitializeDialog из IDialogable сущность ищет файл диалога
//и инициализируется им...

