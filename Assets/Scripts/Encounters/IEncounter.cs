using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEncounter
{
    //string Name { get; }

    //void SetTask(IQuestTask task);
    //void Activate();
    //void Deactivate();
}
public abstract class BaseEncounter : MonoBehaviour, IEncounter
{
    //[SerializeField] protected string _encounterName = string.Empty;

    //public string Name => _encounterName;

    //public abstract void SetTask(IQuestTask task);
    //public abstract void Activate();
    //public abstract void Deactivate();
}

public interface ITaskEncounter : IEncounter
{
    string Name { get; }
    IQuestTask Task { get; }

    void SetTask(IQuestTask task);

    void Activate();
    void Deactivate();
}

public interface IHintableEncounter : ITaskEncounter
{
    void Hint();
}
public interface IDialogableEncounter : IHintableEncounter
{
    void InitializeDialog(string dialogName);
}

public class Encounter : SimpleEncounter, ITaskEncounter
{
    public string Name => _name;
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
