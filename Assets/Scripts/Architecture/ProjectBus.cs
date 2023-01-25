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

    public event Action<SignalContext> OnSignal;

    public void SendSignalByContext(SignalContext context)
    {
        OnSignal?.Invoke(context);
    }
}

public abstract class SignalContext 
{
    public Type Type => GetType(); 
}

public class QuestContext : SignalContext { }
public class SomeContext : SignalContext { }

