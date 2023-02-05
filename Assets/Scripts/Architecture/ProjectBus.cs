using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectBus
{
    #region Singletone
    public static ProjectBus Instance
    {
        get 
        { 
            if(_instance == null) 
                _instance = new ProjectBus();

            return _instance;
        }
    }

    private static ProjectBus _instance = null;
    private ProjectBus() { }

    #endregion

    public event Action<QuestContext> OnQuestContextSignal;
    public event Action<TaskContext> OnTaskContextSignal;

    public event Action<DialogContext> OnDialogContextSignal;

    public void SendSignalByContext(QuestContext context)
    {
        OnQuestContextSignal?.Invoke(context);
    }
    public void SendSignalByContext(TaskContext context)
    {
        OnTaskContextSignal?.Invoke(context);
    }
    public void SendSignalByContext(DialogContext context)
    {
        OnDialogContextSignal?.Invoke(context);
    }
}

public abstract class SignalContext { }

public class DialogContext : SignalContext 
{
    public DialogueCommand Command { get; private set; }
    public string IDName { get; private set; }

    public DialogContext() { }

    public void SetCommand(DialogueCommand command)
    {
        Command = command;
    }
    public void SetID(string name)
    {
        IDName = name;
    }
}

public class QuestContext : SignalContext 
{
    public QuestCommand Command { get; private set; }
    public string IDName { get; private set; }

    public QuestContext() { }

    public void SetCommand(QuestCommand command)
    {
        Command = command;
    }
    public void SetID(string name)
    {
        IDName = name;
    }
}

public class TaskContext : SignalContext
{
    public TaskCommand Command { get; private set; }
    public string IDName { get; private set; }

    public TaskContext() { }

    public void SetCommand(TaskCommand command)
    {
        Command = command;
    }
    public void SetID(string name)
    {
        IDName = name;
    }
}

