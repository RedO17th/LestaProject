using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCleverBoyAndRemember_TheEscape_N3_TalkWithScientist : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _scientistEncounterName = string.Empty;
    [SerializeField] protected string _scientistEncounterDialogName = string.Empty;

    private Scientist _scientist = null;

    public override void Prepare()
    {
        _scientist = _quest.GetNpcEncounterByName(_scientistEncounterName) as Scientist;

        _scientist.SetTask(this);
        _scientist.InitializeDialog(_scientistEncounterDialogName);
        _scientist.Hint();

        //Ключевой момент в отслеживании завершения разговора
        DialogueSceneController.OnDialogueEnd += ProcessEndOfDialogue;

        base.Prepare();
    }

    public override void Activate() => base.Activate();

    private void ProcessEndOfDialogue(BaseDialogue dialogue)
    {
        if (dialogue.Name == _scientistEncounterDialogName)
        {
            if (dialogue.CorrectCompletion)
            {
                DialogueSceneController.OnDialogueEnd -= ProcessEndOfDialogue;

                StopTalkableEncounter();
                FinishTheCurrentTask();
            }
            else
            {
                RestartTalkableEncounter();

                _scientist.OnPlayerMovedAway += PlayerMovedAway;
            }
        }
    }

    private void StopTalkableEncounter()
    {
        _scientist.SuccessfulCompletionOfTheDialogue();
    }

    private void FinishTheCurrentTask()
    {
        var context = new TaskContext();
        context.SetCommand(TaskCommand.Complete);
        context.SetID(_idName);

        ProjectBus.Instance.SendSignalByContext(context);

        //Можно использовать метод ProcessSignal() из BaseQuestTask
    }

    private void RestartTalkableEncounter()
    {
        _scientist.UnsuccessfulCompletionOfTheDialog();
    }

    private void PlayerMovedAway()
    {
        _scientist.OnPlayerMovedAway -= PlayerMovedAway;
        _scientist.Hint();
    }

    protected override void Complete()
    {
        Debug.Log($"RunCleverBoyAndRemember_TheEscape_N3_TalkWithScientist.Complete");

        base.Complete();
    }

    public override void Dectivate()
    {
        base.Dectivate();

        Clear();
    }

    protected override void Clear()
    {
        _scientist = null;
    }
}
