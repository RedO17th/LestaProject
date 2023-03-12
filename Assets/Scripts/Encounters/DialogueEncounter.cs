using UnityEngine;

//Encounter with only task
public class TaskEncounter : SimpleEncounter, ITaskEncounter
{
    public IQuestTask Task => _task;

    protected IQuestTask _task = null;

    public virtual void SetTask(IQuestTask task) { _task = task; }

    public virtual void Activate()
    {
        PrepareTriggerVolume();
    }

    public virtual void Deactivate()
    {
        ClearTriggerVolume();

        _pointer.Disable();
    }
}

//Encounter with task and Dialogue
public class DialogueEncounter : SimpleEncounter, IDialogableEncounter
{
    public bool TaskIsExist => Task != null;
    public IQuestTask Task { get; protected set; }

    public virtual void SetTask(IQuestTask task) 
    {
        Task = task;
        Task.OnCompleted += ProcessTaskComplition;
    }

    public virtual void ProcessTaskComplition() 
    {
        Task.OnCompleted -= ProcessTaskComplition;
        Task = null;
    }

    public virtual void InitializeDialog(string dialogName) { }

    public virtual void SuccessfulCompletionOfTheDialogue() { }
    public virtual void UnsuccessfulCompletionOfTheDialog() { }

    public virtual void Hint() { _pointer.Enable(); }

    public virtual void Activate()
    {
        PrepareTriggerVolume();
    }

    public override void Interact()
    {
        Debug.Log($"EncounterWithDialog.Interact");

        _pointer.Disable();
    }

    public virtual void Deactivate()
    {
        ClearTriggerVolume();

        _pointer.Disable();
    }
}

