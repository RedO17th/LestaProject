using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IStateMachine
{
    event Action<IState> OnStateChanged;

    void Initialize(IEncounter encounter);
    void SetStates(List<IState> states);

    T GetState<T>() where T : BaseState;

    void ActivateDefaultBehaviour();
    void ActivateQuestBehaviour();
    void Tick();

    void Clear();
}

public class BaseStateMachine : MonoBehaviour, IStateMachine
{
    public event Action<IState> OnStateChanged;

    protected List<IState> _states = null;
    protected IState _currentState = null;

    public virtual void Initialize(IEncounter encounter) { }
    public virtual void SetStates(List<IState> states)
    {
        _states = states;
    }
    public virtual T GetState<T>() where T : BaseState
    {
        T result = null;

        foreach (var state in _states)
        {
            if (state is T)
            {
                result = state as T;
                break;
            }
        }

        return result;
    }

    public virtual void ActivateDefaultBehaviour()
    {
        ActivateSomeDefaultState();
    }

    protected virtual void ActivateSomeDefaultState()
    {
        var someDefaultState = FindStateByMark<IDefaultState>();

        if (someDefaultState != null)
        {
            _currentState?.Deactivate();

            _currentState = someDefaultState;

            _currentState.OnCompleted += ProcessDefaultStateCompleting;
            _currentState.Activate();

            OnStateChanged?.Invoke(_currentState);
        }
    }

    protected virtual void ProcessDefaultStateCompleting(IState currentState)
    {
        currentState.OnCompleted -= ProcessDefaultStateCompleting;

        ActivateSomeDefaultState();
    }

    protected virtual IState FindStateByMark<T>() where T : class
    {
        IState result = null;

        foreach (var state in _states.Where(s => s is T))
        {
            if (state.CanPerformAndNotActivated())
            {
                result = state;
                break;
            }
        }

        return result;
    }

    public virtual void ActivateQuestBehaviour()
    {
        var questState = FindStateByMark<IQuestState>();

        if (questState != null)
        {
            _currentState?.Deactivate();

            _currentState = questState;

            _currentState.OnCompleted += ProcessQuestStateCompleting;
            _currentState.Activate();
        
            OnStateChanged?.Invoke(_currentState);
        }
    }

    protected virtual void ProcessQuestStateCompleting(IState currentState)
    {
        currentState.OnCompleted -= ProcessQuestStateCompleting;

        ActivateSomeDefaultState();
    }

    public virtual void Tick() => _currentState?.Tick();

    public virtual void Clear() { }
}

public interface IState
{
    event Action<IState> OnCompleted;

    bool Activated { get; }
    bool CanPerformAndNotActivated();

    void Activate();
    void Tick();
    void Deactivate();
}

public interface IDefaultState { }
public interface IQuestState { }

public abstract class BaseState : IState
{
    public event Action<IState> OnCompleted;

    public bool Activated { get; protected set; } = false;

    public BaseState(IStateMachine stateMachine) { }

    public virtual bool CanPerformAndNotActivated() { return false; }
    public virtual void Activate() { Activated = true; }
    public virtual void Tick() 
    {
        if (Activated == false)
            return;
    }

    protected virtual void OnStateCompleted(IState state) { OnCompleted?.Invoke(state); }

    public virtual void Deactivate() { Activated = false; }
}

public interface IDialogueState
{
    void SetDialogueName(string dialogName);
    void SuccessfulStop();
    void UnsuccessfulStop();
}

public abstract class DialogueState : BaseState, IDialogueState
{
    protected string _dialogueName = string.Empty;

    public DialogueState(IStateMachine stateMachine) : base(stateMachine) { }
    public virtual void SetDialogueName(string dialogueName)
    {
        _dialogueName = dialogueName;
    }

    public virtual void SuccessfulStop() { }
    public virtual void UnsuccessfulStop() { }
}