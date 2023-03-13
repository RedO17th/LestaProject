using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public enum ClassType { None = -1, Class1, Class2, Class3, Class4, Class5, Class6 }

[Serializable]
[CreateAssetMenu(fileName = "ClassContainer", menuName = "ScriptableObjects/Container/ClassContainer")]
public class ClassContainer : BaseDataContainer
{
    [SerializeField] private ClassType _type = ClassType.None;

    [SerializeField] private string _name = string.Empty;

    [SerializeField] private CharacteristicsContainer _startCharacteristicsContainer;

    public ClassType Type => _type;
    public string Name => _name;
}


