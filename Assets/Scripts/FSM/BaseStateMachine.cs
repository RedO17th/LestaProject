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
    void Tick();
}

public class BaseStateMachine : MonoBehaviour, IStateMachine
{
    public event Action<IState> OnStateChanged;

    //protected Dictionary<Type, IState> _states = null;
    
    protected List<IState> _states = null;
    protected IState _currentState = null;

    public virtual void Initialize(IEncounter encounter)
    {
        
    }

    public virtual void SetStates(List<IState> states)
    {
        _states = states;
    }

    public virtual void Tick()
    {
        //if (_currentState == null)
        //{
        //    _currentState = _states.Values.First();
        //}

        //var nextState = _currentState?.Tick();

        //if (nextState != null && nextState != _currentState.GetType())
        //{
        //    SwitchStates(nextState);
        //}

        FindState();

        _currentState?.Tick();
    }

    protected virtual void FindState()
    {
        foreach (var state in _states)
        {
            if (state.CanPerform())
            {
                _currentState = state;
                break;
            }
        }
    }

    protected virtual void SwitchStates(Type newState)
    {
        

        OnStateChanged?.Invoke(_currentState);
    }
}

public interface IState
{
    bool CanPerform();
    Type Tick();
}

public class BaseState : IState
{
    public BaseState(IStateMachine stateMachine) { }
    public virtual bool CanPerform() { return false; }
    public virtual Type Tick() { return GetType(); }
}
