using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEncounter
{
    string Name { get; }

    void SetTask(IQuestTask task);
    void Activate();
    void Deactivate();
}

//public interface ITaskableEncounter : IEncounter
//{
//    void SetTask(IQuestTask task);

//    void Activate();
//    void Deactivate();
//}

public interface IHintableEncounter : IEncounter
{
    void Hint();
}

public interface IDialogableEncounter : IHintableEncounter
{
    void InitializeDialog();
}

public class EncounterWithD : BaseEncounter, IDialogableEncounter
{
    [SerializeField] protected BasePointer _pointer = null;
    [SerializeField] protected string _dialog = string.Empty;

    public override void SetTask(IQuestTask task) { }

    public virtual void InitializeDialog() { }

    public virtual void Hint() { }

    public override void Activate() { }

    public override void Deactivate() { }
}