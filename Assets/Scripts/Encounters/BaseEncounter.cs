using System;
using UnityEngine;

public class BaseEncounter : MonoBehaviour, IEncounter
{
    [SerializeField] protected BasePointer _pointer;
    [SerializeField] protected BaseTriggerVolume _triggerVolume;

    public BaseQuestLink _qestLink = null;

    protected GamePlayer _player = null;

    public virtual void SetQuestLink(BaseQuestLink link)
    {
        _qestLink = link;
    }

    public virtual void Activate() 
    {
        PrepareTriggerVolume();
    }

    protected virtual void PrepareTriggerVolume()
    {
        _triggerVolume.Enable();

        _triggerVolume.OnEnter += PrepareToInteraction;
        _triggerVolume.OnExit += CancelInteraction;
    }

    protected virtual void PrepareToInteraction(GamePlayer player)
    {
        //TODO: Прокинуть все обоюдные ссылки...
        _player = player;
        _player.SetEncounter(this);

        _pointer.Enable();
    }
   
    public virtual void Interact()
    {
        Debug.Log($"BaseEncounter.Interact");

        _pointer.Disable();

        _qestLink.Complete();
    }

    protected virtual void CancelInteraction(GamePlayer player)
    {
        if (_player == player)
        {
            //TODO: Отчистить все обоюдные ссылки...
            _player.RemoveEncounter();
            _player = null;

            _pointer.Disable();
        }
    }

    public virtual void Deactivate()
    {
        ClearTriggerVolume();

        _pointer.Disable();
    }

    protected virtual void ClearTriggerVolume()
    {
        _triggerVolume.OnEnter -= PrepareToInteraction;
        _triggerVolume.OnExit -= CancelInteraction;

        _triggerVolume.Disable();
    }
}
