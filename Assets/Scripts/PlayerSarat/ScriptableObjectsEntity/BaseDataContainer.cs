using System.Collections.Generic;
using UnityEngine;

public class BaseDataContainer : ScriptableObject
{
    public virtual List<string> GetAllNames()
    {
        return new List<string>();
    }
}
