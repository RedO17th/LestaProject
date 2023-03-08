using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerByPlayer : ITriggerVolume
{
    event Action<IPlayer> OnEnter;
    event Action<IPlayer> OnExit;
}

public class TriggerVolumeByPlayer : BaseTriggerVolume, ITriggerByPlayer
{
    public event Action<IPlayer> OnEnter;
    public event Action<IPlayer> OnExit;

    protected override void ProcessingEnter(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<IPlayer>();

        if (player != null)
        {
            OnEnter?.Invoke(player);
        }
    }

    protected override void ProcessingExit(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<IPlayer>();

        if (player != null)
        {
            OnExit?.Invoke(player);
        }
    }
}

public abstract class BaseTaskVolume : BaseVolume, ITaskVolumeEncounter
{
    [SerializeField] protected string _name = string.Empty;
    public string Name => _name;

    protected IQuestTask _questTask = null;
    protected ITriggerByPlayer _triggerVolume = null;

    protected virtual void Awake()
    {
        _triggerVolume = GetComponent<ITriggerByPlayer>();
    }

    public virtual void SetTask(IQuestTask task) { _questTask = task; }

    public virtual void Activate() { }
    public virtual void Deactivate() { }
}