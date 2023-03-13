using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "ClassesSettings", menuName = "ScriptableObjects/Container/ClassesSettings")]
public class ClassesSettings : BaseDataContainer
{
    [SerializeField] private List<ClassContainer> _classes;

    public ClassContainer GetClassByType(ClassType type)
    {
        return _classes.Find(x => x.Type.Equals(type));
    }

    public ClassType GetClassTypeByName(string name)
    {
        return _classes.Find(x => x.Type.ToString().ToLower().Equals(name.ToLower())).Type;
    }
}

