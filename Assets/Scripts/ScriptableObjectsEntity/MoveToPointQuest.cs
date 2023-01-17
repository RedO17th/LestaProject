using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveToPoint", menuName = "ScriptableObjects/Quests/MoveToPoint")]
public class MoveToPointQuest : BaseQuest
{
    public override void Initialize(QuestSubSystem system)
    {
        base.Initialize(system);
    }

    public override void Prepare() { }

    public override void Launch() { }

    protected override bool CheckConditionOfCompliting() => true;

    public override void Complete()
    {
        Debug.Log($"MoveTo.Complete");
    }
}
