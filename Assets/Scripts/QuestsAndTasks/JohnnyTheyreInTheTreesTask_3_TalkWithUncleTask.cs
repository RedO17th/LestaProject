using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnnyTheyreInTheTreesTask_3_TalkWithUncleTask : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _uncleEncounterName = string.Empty;
    [SerializeField] protected string _uncleEncounterDialogName = string.Empty;

    private DialogueEncounter _uncle = null;

    public override void Prepare()
    {
        _uncle = _quest.GetNpcEncounterByName(_uncleEncounterName) as DialogueEncounter;

        _uncle.SetTask(this);
        _uncle.InitializeDialog(_uncleEncounterDialogName);
        _uncle.Hint();

        DialogueSceneController.OnDialogueEnd += ProcessEndOfDialogue;

        base.Prepare();
    }

    public override void Activate() => base.Activate();

    private void ProcessEndOfDialogue(BaseDialogue dialogue)
    {
        if (dialogue.Name == _uncleEncounterDialogName)
        {
            if (dialogue.CorrectCompletion)
            {
                DialogueSceneController.OnDialogueEnd -= ProcessEndOfDialogue;

                FinishTheCurrentTask();
            }
            else
            {
                _uncle.OnPlayerMovedAway += PlayerMovedAway;
            }
        }
    }

    private void FinishTheCurrentTask()
    {
        var context = new TaskContext();
            context.SetCommand(TaskCommand.Complete);
            context.SetID(_idName);

        ProjectBus.Instance.SendSignalByContext(context);

        //Можно использовать метод ProcessSignal() из BaseQuestTask
    }

    private void PlayerMovedAway()
    {
        _uncle.OnPlayerMovedAway -= PlayerMovedAway;
        _uncle.Hint();
    }

    protected override void Complete()
    {
        Debug.Log($"JohnnyTheyreInTheTreesTask_3_TalkWithUncleTask.Complete");

        base.Complete();
    }

    public override void Dectivate()
    {
        base.Dectivate();

        _uncle.Deactivate();

        Clear();
    }

    protected override void Clear()
    {
        _uncle = null;
    }
}
