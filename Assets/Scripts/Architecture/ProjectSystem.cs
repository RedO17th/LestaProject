using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum SubSystemType { None = -1, UISubSystem, SoundSubSystem }

public class ProjectSystem : MonoBehaviour
{
    [SerializeField] private List<BaseProjectSubSystem> _subsystems;

    [Header("Player")]
    [SerializeField] private BasePlayer _player;

    #region Singleton instance
    public static ProjectSystem Instance => _instance;

    private static ProjectSystem _instance = null;
    #endregion

    private void Awake()
    {
        InitializeSystem();
        InitializeSubSystems();
    }

    private void InitializeSystem()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void InitializeSubSystems()
    {
        foreach (var s in _subsystems)
            s.Initialize(this);
    }

    public BaseProjectSubSystem GetSubSystemBy(SubSystemType type)
    {
        return _subsystems.Where(s => s.Type == type) as BaseProjectSubSystem;
    }
}
