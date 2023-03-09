using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfTheBlueTask_2_TalkAboutSituation : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _dialogueAbout = string.Empty;

    private IDialogueInvoker _dialogueVolume = null;

    public override void Prepare()
    {
        _dialogueVolume = _quest.GetInvokerEncounterByName(_dialogueAbout) as IDialogueInvoker;

        DialogueSceneController.OnDialogueEnd += ProcessEndOfDialogue;

        base.Prepare();
    }

    public override void Activate()
    {
        base.Activate();

        _dialogueVolume.Activate();

    }

    private void ProcessEndOfDialogue(BaseDialogue dialogue)
    {
        if (dialogue.Name == _dialogueVolume.DialogueName)
        {
            if (dialogue.CorrectCompletion)
            {
                DialogueSceneController.OnDialogueEnd -= ProcessEndOfDialogue;

                FinishTheCurrentTask();
            }
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
        Debug.Log($"OutOfTheBlueTask_2_TalkAboutSituation.Complete");

        base.Complete();
    }

    public override void Dectivate()
    {
        _dialogueVolume.Deactivate();

        base.Dectivate();

        Clear();
    }

    protected override void Clear()
    {
        _dialogueVolume = null;
    }
}
