using UnityEngine;

public abstract class BaseProjectSubSystem : MonoBehaviour
{
    [SerializeField] private SubSystemType _type = SubSystemType.None;

    public SubSystemType Type => _type;

    private ProjectSystem _projectSystem = null;

    public virtual void Initialize(ProjectSystem system)
    {
        _projectSystem = system;
    }
}
