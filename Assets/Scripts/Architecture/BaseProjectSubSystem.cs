using UnityEngine;

public abstract class BaseProjectSubSystem : MonoBehaviour
{
    private ProjectSystem _projectSystem = null;

    public virtual void Initialize(ProjectSystem system)
    {
        _projectSystem = system;
    }
}

