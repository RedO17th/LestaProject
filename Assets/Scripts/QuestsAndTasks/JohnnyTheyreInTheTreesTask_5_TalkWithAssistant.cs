using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnnyTheyreInTheTreesTask_5_TalkWithAssistant : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _dogEncounterName = string.Empty;
    [SerializeField] protected string _dogEncounterDialogName = string.Empty;

    private BasePlayerAssistant _assistant = null;

    public override void Prepare()
    {
        _assistant = _quest.GetNpcEncounterByName(_dogEncounterName) as BasePlayerAssistant;

        _assistant.SetTask(this);
        _assistant.InitializeDialog(_dogEncounterDialogName);
        _assistant.Hint();

        DialogueSceneController.OnDialogueEnd += ProcessEndOfDialogue;

        base.Prepare();
    }

    public override void Activate() => base.Activate();

    private void ProcessEndOfDialogue(BaseDialogue dialogue)
    {
        if (dialogue.Name == _dogEncounterDialogName)
        {
            if (dialogue.CorrectCompletion)
            {
                DialogueSceneController.OnDialogueEnd -= ProcessEndOfDialogue;

                FinishTheCurrentTask();
            }
            else
            {
                _assistant.OnPlayerMovedAway += PlayerMovedAway;
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

    private void PlayerMovedAway()
    {
        _assistant.OnPlayerMovedAway -= PlayerMovedAway;
        _assistant.Hint();
    }

    protected override void Complete()
    {
        Debug.Log($"JohnnyTheyreInTheTreesTask_5_TalkWithAssistant.Complete");

        base.Complete();
    }

    public override void Dectivate()
    {
        base.Dectivate();

        Clear();
    }

    protected override void Clear()
    {
        _assistant = null;
    }
}
