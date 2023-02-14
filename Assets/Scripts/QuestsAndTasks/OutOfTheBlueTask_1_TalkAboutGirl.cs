using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfTheBlueTask_1_TalkAboutGirl : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _girlName = string.Empty;
    [SerializeField] protected string _dialogueName = string.Empty;

    [SerializeField] protected string _freeDialogueName = string.Empty;

    private IDialogableEncounter _girl = null;
    private IContextInvoker _dialogueVolume = null;

    public override void Prepare()
    {
        _girl = _quest.GetNpcEncounterByName(_girlName) as IDialogableEncounter;
        _girl.SetTask(this);
        _girl.InitializeDialog(_dialogueName);

        _dialogueVolume = _quest.GetInvokerEncounterByName(_freeDialogueName) as IContextInvoker;

        DialogueSceneController.OnDialogueEnd += ProcessEndOfDialogue;

        base.Prepare();
    }

    public override void Activate()
    {
        _girl.Activate();
        _girl.Hint();

        base.Activate();
    }

    private void ProcessEndOfDialogue(BaseDialogue dialogue)
    {
        if (dialogue.Name == _dialogueName)
        {
            DialogueSceneController.OnDialogueEnd -= ProcessEndOfDialogue;

            FinishTheCurrentTask();
        }
    }

    private void FinishTheCurrentTask()
    {
        var context = new TaskContext();
            context.SetCommand(TaskCommand.Complete);
            context.SetID(_idName);

        ProjectBus.Instance.SendSignalByContext(context);
    }

    protected override void Complete()
    {
        Debug.Log($"OutOfTheBlueTask_1_TalkAboutGirl.Complete");

        base.Complete();
    }

    public override void Dectivate()
    {
        _dialogueVolume.Activate();

        base.Dectivate();

        Clear();
    }

    protected override void Clear()
    {
        _dialogueVolume = null;
        _girl = null;
    }
}
