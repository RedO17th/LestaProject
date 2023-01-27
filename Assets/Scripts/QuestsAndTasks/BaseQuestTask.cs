using System;
using UnityEngine;

public enum TaskState { None = -1, UnActivated, Activated, Completed, Failed }

public class BaseQuestTask : MonoBehaviour
{
    [SerializeField] protected TaskState _state = TaskState.UnActivated;

    [SerializeField] protected string _name;
    [SerializeField] protected string _description = string.Empty;

    public event Action<BaseQuestTask> OnCompleted;

    public TaskState State => _state;

    protected BaseQuest _quest = null;

    public virtual void Initialize(BaseQuest quest)
    {
        _quest = quest;
    }

    public virtual void Prepare() { }

    public virtual void Activate() 
    {
        _state = TaskState.Activated;
    }

    protected virtual void ProcessCorrectCompletion()
    {
        if (CheckConditionOfCompliting())
            Complete();
    }
    protected virtual bool CheckConditionOfCompliting() { return true; }
    protected virtual void Complete()
    {
        _state = TaskState.Completed;

        OnCompleted?.Invoke(this);
    }

    //Как завершить задачу через Failed...
    protected virtual void ProcessFailedCompletion()
    {
        if (CheckConditionOfFailed())
            Failed();
    }
    protected virtual bool CheckConditionOfFailed() { return false; }
    protected virtual void Failed()
    {
        _state = TaskState.Failed;

        OnCompleted?.Invoke(this);
    }

    public virtual void Dectivate() { }
    protected virtual void Clear() { }
}
