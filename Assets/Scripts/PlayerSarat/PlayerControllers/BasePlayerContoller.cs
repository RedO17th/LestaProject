using System.Diagnostics.Tracing;
using UnityEngine;

public enum PlayerControllerType { None = -1, Movement, Ability, Inventory, Animator, Damage }

public abstract class BasePlayerContoller : MonoBehaviour
{
    [SerializeField] private PlayerControllerType _type = PlayerControllerType.None;

    public bool IsEnabled { get; protected set; } = true;
    public PlayerControllerType Type => _type;
    public GamePlayer Player => _player;

    protected GamePlayer _player = null;

    public virtual void Initialize(BasePlayer player)
    {
        _player = player as GamePlayer;
    }

    public virtual void Prepare() {}

    public virtual void Enable() => IsEnabled = true;
    public virtual void Disable() => IsEnabled = false;
}
