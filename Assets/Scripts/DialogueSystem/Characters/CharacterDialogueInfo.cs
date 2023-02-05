using System;
using UnityEngine;

[Serializable]
public class CharacterDialogueInfo
{
    [SerializeField] string _name = string.Empty;
    [SerializeField] string _tag = string.Empty;
    [SerializeField] Sprite _portreit = null;

    public string Name
    {
        get { return _name; }
    }

    public string Tag
    {
        get { return _tag; }
    }

    public Sprite Portreit
    {
        get { return _portreit; }
    }
}
