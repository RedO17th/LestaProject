using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalkWithDog", menuName = "ScriptableObjects/Quests/TalkWithDog")]
public class TalkWithDogQuest : Quest
{
    public override void Complete()
    {
        Debug.Log($"TalkWithDog.Complete");

        base.Complete();
    }
}
