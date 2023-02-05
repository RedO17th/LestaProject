using System;
using UnityEngine;

public enum TaskCommand { None = -1, Activate, Complete, Fail }
public enum TaskState { None = -1, UnActivated, Activated, Completed, Failed }

public interface IQuestTask
{
    event Action OnCompleted;

    public TaskState State { get; }
    public string IDName { get; }
}

public class BaseQuestTask : MonoBehaviour, IQuestTask
{
    [SerializeField] protected TaskState _state = TaskState.UnActivated;

    [SerializeField] protected string _idName = string.Empty;
    [SerializeField] protected string _name;
    [SerializeField] protected string _description = string.Empty;

    public event Action OnCompleted;

    public TaskState State => _state;
    public string IDName => _idName;

    protected BaseQuest _quest = null;
    protected TaskContext _context = null;

    public virtual void Initialize(BaseQuest quest)
    {
        _quest = quest;
    }

    public virtual void Prepare() 
    {
        ProjectBus.Instance.OnTaskContextSignal += ProcessSignal;
    }

    public virtual void Activate() 
    {
        _state = TaskState.Activated;
    }

    protected virtual void ProcessSignal(TaskContext context) 
    {
        _context = context;

        ProcessCommandFromSignal();
    } 
    protected virtual void ProcessCommandFromSignal()
    {
        switch (_context.Command)
        {
            case TaskCommand.Activate:
            case TaskCommand.Fail:
            case TaskCommand.Complete:
                {
                    ProcessCorrectCompletion();
                    break;
                }
        }
    }

    protected virtual void ProcessCorrectCompletion()
    {
        if (CheckConditionOfCompliting())
            Complete();
    }
    protected virtual bool CheckConditionOfCompliting() 
    {
        return _context.IDName == _idName;
    }
    protected virtual void Complete()
    {
        _context = null;

        _state = TaskState.Completed;

        OnCompleted?.Invoke();
    }

    protected virtual void ProcessFailedCompletion()
    {
        if (CheckConditionOfFailed())
            Failed();
    }
    protected virtual bool CheckConditionOfFailed() { return false; }
    protected virtual void Failed()
    {
        _state = TaskState.Failed;

        OnCompleted?.Invoke();
    }

    public virtual void Dectivate() 
    {
        ProjectBus.Instance.OnTaskContextSignal -= ProcessSignal;
    }
    protected virtual void Clear() { }
}
