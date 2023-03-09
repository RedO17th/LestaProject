using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivatable
{
    void Activate();
    void Deactivate();
}

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

public interface ITaskEncounter : IEncounter, IActivatable, ITaskable
{
    IQuestTask Task { get; }
}

public interface IHintableEncounter : ITaskEncounter
{
    void Hint();
}
public interface IDialogableEncounter : IHintableEncounter
{
    void InitializeDialog(string dialogName);
}

public interface ITaskVolumeEncounter : IEncounter, IActivatable, ITaskable { }