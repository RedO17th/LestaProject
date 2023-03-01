using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader
{
    object Load(object data);
}

public interface ISaver
{
    void Save(object data);
}

public class LoadSubSystem : BaseSubSystem, ILoader, ISaver
{
    [SerializeField] private string _filePath = string.Empty;
    [SerializeField] private string _fileName = string.Empty;

    private Storage _storage = null;

    protected override void Awake()
    {
        _storage = new Storage(_filePath, _fileName);   
    }

    public override void Initialize() { }
    public override void Prepare() { }
    public override void StartSystem() { }


    public object Load(object data)
    {




        return null;
    }

    public void Save(object data)
    {
        
    }

    public override void Clear()
    {
        
    }
}
