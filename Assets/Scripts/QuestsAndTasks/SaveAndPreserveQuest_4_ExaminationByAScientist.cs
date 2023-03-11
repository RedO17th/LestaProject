using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndPreserveQuest_4_ExaminationByAScientist : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _scientistEncounterName = string.Empty;
    [SerializeField] protected string _scientistEncounterDialogName = string.Empty;

    private Scientist _scientist = null;

    #region ToRemove
    [Space]
    [SerializeField] protected string _dogEncounterName = string.Empty;
    [SerializeField] protected Vector3 _dogPosition = Vector3.zero;
    private Dog _dog = null;

    [Space]
    [SerializeField] protected string _girlEncounterName = string.Empty;
    [SerializeField] protected Vector3 _girlPosition = Vector3.zero;
    private Girl _girl = null;

    [Space]
    [SerializeField] protected Vector3 _scientistPosition = Vector3.zero;
    #endregion

    public override void Prepare()
    {
        _scientist = _quest.GetNpcEncounterByName(_scientistEncounterName) as Scientist;

        _scientist.SetTask(this);
        _scientist.InitializeDialog(_scientistEncounterDialogName);
        _scientist.Hint();

        //[TODO] Remove
        _dog = _quest.GetNpcEncounterByName(_dogEncounterName) as Dog;
        _girl = _quest.GetNpcEncounterByName(_girlEncounterName) as Girl;
        //..

        DialogueSceneController.OnDialogueEnd += ProcessEndOfDialogue;

        base.Prepare();
    }

    public override void Activate()
    {
        base.Activate();

        //Remove
        _dog.transform.position = _dogPosition;
        _girl.transform.position = _girlPosition;
        _scientist.transform.position = _scientistPosition;
        //..
    }

    private void ProcessEndOfDialogue(BaseDialogue dialogue)
    {
        if (dialogue.Name == _scientistEncounterDialogName)
        {
            if (dialogue.CorrectCompletion)
            {
                DialogueSceneController.OnDialogueEnd -= ProcessEndOfDialogue;

                FinishTheCurrentTask();
            }
            else
            {
                _scientist.OnPlayerMovedAway += PlayerMovedAway;
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
        _scientist.OnPlayerMovedAway -= PlayerMovedAway;
        _scientist.Hint();
    }

    protected override void Complete()
    {
        Debug.Log($"SaveAndPreserveQuest_3_TalkWithScientist.Complete");

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

        //..
        _girl = null;
        _dog = null;
    }
}
