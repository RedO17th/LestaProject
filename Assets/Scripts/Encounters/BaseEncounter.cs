using UnityEngine;

public class BaseEncounter : MonoBehaviour, IEncounter
{
    [SerializeField] protected BasePointer _pointer;
    [SerializeField] protected BaseTriggerVolume _triggerVolume;

    protected GamePlayer _player = null;

    //Test
    private void Awake()
    {
        Activate();
    }
    //

    public virtual void Initialize(Component manager)
    { 
        
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
        //TODO: ��������� ��� �������� ������...
        _player = player;
        _player.SetEncounter(this);

        _pointer.Enable();
    }
   

    //�������� ����� ��������������
    public virtual void Interact()
    {
        Debug.Log($"BaseEncounter.Interact");

        _pointer.Disable();
    }

    protected virtual void CancelInteraction(GamePlayer player)
    {
        if (_player == player)
        {
            //TODO: ��������� ��� �������� ������...
            _player.RemoveEncounter();
            _player = null;
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
