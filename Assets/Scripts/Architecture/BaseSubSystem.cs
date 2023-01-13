using UnityEngine;

public abstract class BaseSubSystem : MonoBehaviour
{
    protected ProjectSystem _projectSystem = null;

    public virtual void Initialize(ProjectSystem system)
    {
        _projectSystem = system;
    }

    public virtual void Prepare() { }
    public virtual void StartSystem() { }
    public virtual void Clear() { }
}

