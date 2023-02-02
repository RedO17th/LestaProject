using UnityEngine;

public class EncounterWithDialog : SimpleEncounter, IDialogableEncounter
{
    public string Name => _name;
    public IQuestTask Task => _task;

    protected IQuestTask _task = null;

    public virtual void SetTask(IQuestTask task) 
    {
        _task = task;
        _task.OnCompleted += ProcessTaskComplition;
    }

    //[Think] У задачи могут быть разные состояния при завершении, обдумать этот момент
    public virtual void ProcessTaskComplition() 
    {
        _task.OnCompleted -= ProcessTaskComplition;
        _task = null;
    }

    public virtual void InitializeDialog(string dialogName) { }

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