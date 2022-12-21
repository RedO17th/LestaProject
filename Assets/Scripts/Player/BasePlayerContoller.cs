using System.Diagnostics.Tracing;
using UnityEngine;

public enum PlayerControllerType { None = -1, Movement, Ability, Inventory, Animator }

public abstract class BasePlayerContoller : MonoBehaviour
{
    [SerializeField] private PlayerControllerType _type = PlayerControllerType.None;

    public bool IsEnabled { get; protected set; } = true;
    public PlayerControllerType Type => _type;

    protected BasePlayer _player = null;

    public virtual void Initialize(BasePlayer player)
    {
        _player = player;
    }

    public virtual void Enable() => IsEnabled = true;
    public virtual void Disable() => IsEnabled = false;
}
