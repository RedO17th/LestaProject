using System;
using UnityEngine;

public enum TaskState { None = -1, UnActivated, Activated, Completed, Failed }

[CreateAssetMenu]
public class BaseQuestTask : ScriptableObject
{
    [SerializeField] protected TaskState _state = TaskState.UnActivated;

    [SerializeField] private string _name;
    [SerializeField] protected string _description = string.Empty;

    public event Action OnCompleted;

    public TaskState State => _state;

    protected BaseQuest _quest = null;

    public virtual void Initialize(BaseQuest quest)
    {
        _quest = quest;
    }

    //Метод для получения необходимых данных
    public virtual void Prepare()
    { 
        
    }

    public virtual void Activate()
    {

    }

    protected virtual void CheckCompliting()
    {
        if (CheckConditionOfCompliting())
            Complete();
    }
    protected virtual bool CheckConditionOfCompliting() { return false; }
    protected virtual void Complete()
    {
        Debug.Log($"BaseQuest.Complete");

        _state = TaskState.Completed;

        OnCompleted?.Invoke();
    }

    //Как завершить задачу через Failed
    protected virtual void CheckFailedCompliting()
    {
        _state = TaskState.Failed;

        OnCompleted?.Invoke();
    }

    public virtual void Dectivate() { }
    protected virtual void Clear() { }
}
