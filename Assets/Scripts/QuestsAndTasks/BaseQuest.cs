using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestCommand { None = -1, Open, Close, Activate, Deactivate, Complete, Fail }
public enum QuestState { None = -1, Opened, Closed, Activated, Completed, Failed }

public class BaseQuest : MonoBehaviour, IQuestNote
{
    [SerializeField] protected QuestState _state = QuestState.Closed;

    [SerializeField] protected string _idName = string.Empty;
    [SerializeField] protected string _name = string.Empty;

    [TextArea]
    [SerializeField] protected string _description = string.Empty;
    [SerializeField] private Reward _reward;

    [SerializeField] protected List<BaseQuestTask> _taskPrefabs;

    public event Action<BaseQuest> OnQuestComplete;

    public string IDName => _idName;
    public string Id => _idName;
    public string Header => _name;
    public string Content => _description;
    public Reward Reward => _reward;

    protected QuestSubSystem _questSubSystem = null;

    protected List<BaseQuestTask> _tasks = null;

    protected List<IEncounter> _npcEncounters = null;
    protected List<IEncounter> _volumesEncounters = null;
    protected List<IEncounter> _invokerEncounter = null;

    protected BaseQuestTask _currentTask = null;

    public bool StateIs(QuestState checkableState)
    {
        return _state == checkableState;
    }

    #region Add encounters

    public virtual void AddNpcEncounters(List<IEncounter> encounters)
    {
        _npcEncounters = encounters;
    }
    public virtual void AddVolumeEncounters(List<IEncounter> encounters)
    {
        _volumesEncounters = encounters;
    }
    public virtual void AddInvokerEncounters(List<IEncounter> encounters)
    {
        _invokerEncounter = encounters;
    }

    #endregion

    #region Get encounters

    public virtual IEncounter GetNpcEncounterByName(string name)
    {
        IEncounter result = null;

        foreach (var encounter in _npcEncounters)
        {
            if (encounter.Name == name)
            {
                result = encounter;
                break;
            }
        }

        return result;
    }

    public virtual IEncounter GetVolumeEncounterByName(string name)
    {
        IEncounter result = null;

        foreach (var encounter in _volumesEncounters)
        {
            if (encounter.Name == name)
            {
                result = encounter;
                break;
            }
        }

        return result;
    }

    public virtual IEncounter GetInvokerEncounterByName(string name)
    {
        IEncounter result = null;

        foreach (var encounter in _invokerEncounter)
        {
            if (encounter.Name == name)
            {
                result = encounter;
                break;
            }
        }

        return result;
    }

    #endregion

    public virtual void Initialize(QuestSubSystem system)
    {
        _questSubSystem = system;
    }

    public virtual void Prepare()
    {
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
        Debug.Log($"BaseQuest.Activate: Quest name is { _idName } ");
        StartTaskExecution();
    }

    protected virtual void StartTaskExecution()
    {
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
        _currentTask.OnCompleted -= ProcessTaskCompletion;
        _currentTask.Dectivate();

        var taskState = _currentTask.State;

        _currentTask = null;

        if (taskState == TaskState.Completed)
        {
            ProcessCorrectCompletion();
        }
        else if (taskState == TaskState.Failed)
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

        OnQuestComplete?.Invoke(this);
    }

    protected virtual void ContinueCompletingTasks() => StartTaskExecution();

    protected virtual void ProcessFailedCompletion() { }

    public virtual void Dectivate() { }
    protected virtual void Clear() { }
}
