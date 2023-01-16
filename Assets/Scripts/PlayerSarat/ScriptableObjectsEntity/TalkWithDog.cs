using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalkWithDog", menuName = "ScriptableObjects/Quests/TalkWithDog")]
public class TalkWithDog : BaseQuest
{
    public override void Initialize(QuestSubSystem system)
    {
        base.Initialize(system);
    }

    public override void Complete()
    {
        Debug.Log($"TalkWithDog.Complete");

        base.Complete();
    }
}
