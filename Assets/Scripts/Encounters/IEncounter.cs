using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INamable
{
    string Name { get; }
}

public interface IEncounter : INamable { }

public abstract class BaseEncounter : MonoBehaviour, IEncounter
{
    [SerializeField] protected string _name = string.Empty;

    public string Name => _name;
}

public interface ITaskable
{
    void SetTask(IQuestTask task);
}

public interface ITaskEncounter : IEncounter, ITaskable
{
    IQuestTask Task { get; }

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
