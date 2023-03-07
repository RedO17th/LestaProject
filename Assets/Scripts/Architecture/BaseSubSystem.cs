using UnityEngine;

public abstract class BaseSubSystem : MonoBehaviour
{
    protected virtual void Awake() { }

    public virtual void Initialize() { }

    public virtual void Prepare() { }
    public virtual void StartSystem() { }

    public virtual void StopSystem() { }

    public virtual void Clear() { }
}

