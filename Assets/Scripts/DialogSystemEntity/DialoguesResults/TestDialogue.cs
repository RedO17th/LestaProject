using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : BaseDialogue
{
    public override void ProcessCommandViaTag(string tag)
    {
        Debug.Log($"TestDialogue.ProcessCommandViaTag: tag is {tag} ");
    }
}
