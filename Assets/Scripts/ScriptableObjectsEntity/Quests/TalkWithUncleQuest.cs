using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalkWithUncle", menuName = "ScriptableObjects/Quests/TalkWithUncle")]
public class TalkWithUncleQuest : BaseQuest
{
    public override void Complete()
    {
        Debug.Log($"TalkWithUncleQuest.Complete");

        base.Complete();
    }
}
