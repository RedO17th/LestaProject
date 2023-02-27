using System.Diagnostics.Tracing;
using UnityEngine;

public abstract class BasePlayerContoller : MonoBehaviour
{
    public bool IsEnabled { get; protected set; } = true;
    public BasePlayer Player => _player;

    protected BasePlayer _player = null;

    public virtual void Initialize(BasePlayer player)
    {
        _player = player;
    }

    public virtual void Prepare() {}

    public virtual void Enable() => IsEnabled = true;
    public virtual void Disable() => IsEnabled = false;
}
