using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    protected PlayerSubSystem _playerSystem = null;

    //TODO: Создать сущность Health

    public virtual void Initialize(PlayerSubSystem system)
    {
        _playerSystem = system;
    }

    #region Health part

    //TODO: Если не пригодится, то убрать...
    public virtual void SetDamage() { }

    #endregion

    #region Wallet part
    //TODO: Если не пригодится, то убрать...

    public virtual void AddPoints(int points)
    {
        _playerSystem.AddPoints(points);
    }

    #endregion
}
