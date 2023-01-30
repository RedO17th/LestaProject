using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestCommand { None = -1, Open, Close, Activate, Deactivate, Complete, Fail }
public enum QuestState { None = -1, Opened, Closed, Activated, Completed, Failed }

public class BaseQuest : MonoBehaviour
{
    [SerializeField] protected QuestState _state = QuestState.Closed;

    [SerializeField] protected string _idName = string.Empty;

    [SerializeField] protected string _name = string.Empty;
    [SerializeField] protected string _description = string.Empty;

    [SerializeField] protected List<BaseQuestTask> _taskPrefabs;

    public string IDName => _idName;

    protected QuestSubSystem _questSubSystem = null;

    protected List<BaseQuestTask> _tasks = null;
    protected List<ITaskEncounter> _encounters = null;

    public bool StateIs(QuestState checkableState)
    {
        return _state == checkableState;
    }

    public virtual void AddEncounters(List<ITaskEncounter> encounters)
    {
        _encounters = encounters;
    }
    public virtual ITaskEncounter GetEncounterByName(string name)
    {
        ITaskEncounter result = null;

        foreach (var encounter in _encounters)
        {
            if (encounter.Name == name)
            {
                result = encounter;
                break;
            }
        }

        return result;
    }

    public virtual void Initialize(QuestSubSystem system)
    {
        _questSubSystem = system;
    }

    public virtual void Prepare()
    {
        Debug.Log($"BaseQuest.Prepare");

        CreateTasks();
        InitializeTasks();
    }

    protected virtual void CreateTasks()
    {
        _tasks = new List<BaseQuestTask>();

        foreach (var prefab in _taskPrefabs)
        {
            var task = CreateTask(prefab);
                _tasks.Add(task);
        }
    }
    protected virtual BaseQuestTask CreateTask(BaseQuestTask prefab)
    {
        return Instantiate(prefab, transform);
    }
    protected virtual void InitializeTasks()
    {
        foreach (var task in _tasks)
            task.Initialize(this);
    }

    public virtual void Activate()
    {
        Debug.Log($"BaseQuest.Activate");
        StartTaskExecution();
    }

    protected virtual void StartTaskExecution()
    {
        var task = GetUnactivatedTask();

        if (task)
        {
            _state = QuestState.Activated;

            task.OnCompleted += ProcessTaskCompletion;

            task.Prepare();
            task.Activate();
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

    protected virtual void ProcessTaskCompletion(BaseQuestTask task)
    {
        task.OnCompleted -= ProcessTaskCompletion;
        task.Dectivate();
        //[ForMe] Удалять задачу...

        if (task.State == TaskState.Completed)
        {
            ProcessCorrectCompletion();
        }
        else if (task.State == TaskState.Failed)
        {
            //ProcessFailedCompletion();
        }
    }

    protected virtual void ProcessCorrectCompletion() 
    {
        if (CheckConditionOfQuestCompliting())
            Complete();
        else
            ContinueCompletingTasks();
    }
    protected virtual bool CheckConditionOfQuestCompliting()
    {
        bool result = true;

        foreach (var task in _tasks)
        {
            if (task.State != TaskState.Completed)
                result = false;
        }

        return result;
    }
    protected virtual void Complete()
    {
        Debug.Log($"BaseQuest.Complete");

        _state = QuestState.Completed;
    }

    protected virtual void ContinueCompletingTasks() => StartTaskExecution();

    protected virtual void ProcessFailedCompletion() { }

    public virtual void Dectivate() { }
    protected virtual void Clear() { }
}
