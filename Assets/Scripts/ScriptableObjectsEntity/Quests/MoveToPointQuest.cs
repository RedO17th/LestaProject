using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveToPoint", menuName = "ScriptableObjects/Quests/MoveToPoint")]
public class MoveToPointQuest : BaseQuest
{
    public override void Complete()
    {
        Debug.Log($"MoveTo.Complete");

        base.Complete();
    }
}
