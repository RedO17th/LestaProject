using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISubSystem : BaseSubSystem
{
    [SerializeField] private BaseWindow[] _windows = null;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);

        InitializeWindows();
    }

    public void InitializeWindows()
    {
        foreach (var window in _windows)
            window.Initialize(this);
    }

}
