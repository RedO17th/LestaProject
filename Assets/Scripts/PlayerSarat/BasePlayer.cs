using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    protected PlayerSubSystem _playerSystem = null;

    public virtual void Initialize(PlayerSubSystem system)
    {
        _playerSystem = system;
    }
}
