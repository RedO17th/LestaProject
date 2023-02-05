using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : BaseDialogue
{
    public override void ProcessCommandViaTag(string tag)
    {
        Debug.Log($"Dialogue.ProcessCommandViaTag: tag is {tag} ");
    }
}