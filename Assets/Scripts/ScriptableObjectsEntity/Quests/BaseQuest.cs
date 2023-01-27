using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestCommand { None = -1, Open, Close, Activate, Deactivate, Complete, Fail }
public enum QuestState { None = -1, Opened, Closed, Activated, Completed, Failed }

[CreateAssetMenu]
public class BaseQuest : ScriptableObject
{
    [SerializeField] protected QuestState _state = QuestState.Closed;

    [SerializeField] protected string _idName = string.Empty;

    [SerializeField] protected string _name = string.Empty;
    [SerializeField] protected string _description = string.Empty;

    [SerializeField] protected List<BaseQuestTask> _tasks;

    public string IDName => _idName;

    protected QuestSubSystem _questSubSystem = null;
    protected BaseQuestTask _currentTask = null;

    public virtual void Initialize(QuestSubSystem system)
    {
        _questSubSystem = system;
    }

    public bool StateIs(QuestState checkableState)
    {
        return _state == checkableState;
    }

    public virtual void Prepare()
    {
        Debug.Log($"BaseQuest.Prepare");

        InitializeAndPrepareTasks();
    }

    protected virtual void InitializeAndPrepareTasks()
    {
        foreach (var task in _tasks)
        {
            task.Initialize(this);
            task.Prepare();
        }
    }

    public virtual void Activate()
    {
        Debug.Log($"BaseQuest.Activate");

        //Вынести в отдельный метод
        _currentTask = GetUnactivatedTask();

        if (_currentTask)
        {
            _state = QuestState.Activated;

            _currentTask.OnCompleted += ProcessTaskCompletion;

            _currentTask.Prepare();
            _currentTask.Activate();     
            


        }
    }

    protected virtual BaseQuestTask GetUnactivatedTask()
    {
        BaseQuestTask result = null;

        foreach (var task in _tasks)
        {
            if (task.State == TaskState.UnActivated)
            {
                result = task;
                break;
            }
        }

        return result;
    }

    protected virtual void ProcessTaskCompletion()
    {
        if (_currentTask)
        {
            _currentTask.OnCompleted -= ProcessTaskCompletion;

            if (_currentTask.State == TaskState.Completed)
            {
                //Корректное завершение
                //CheckCompliting();
            }
            else if (_currentTask.State == TaskState.Failed)
            {
                //Не корректное завершение
                //ProcessFailedCompletion();
            }

            //_currentTask.Dectivate();
        }
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

        _state = QuestState.Completed;
    }

    protected virtual void ProcessFailedCompletion()
    { 
        


    }

    public virtual void Dectivate() { }
    protected virtual void Clear() { }
}
