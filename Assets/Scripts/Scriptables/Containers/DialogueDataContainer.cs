using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObjects/Container/DialogueData")]
public class DialogueDataContainer : BaseDataContainer
{
    [SerializeField] private BaseDialogue[] _dialogues;

    public BaseDialogue GetDialogueByName(string name)
    {
        BaseDialogue result = null;
        foreach (var dialogue in _dialogues)
        {
            if(dialogue.Name.Equals(name))
            {
                result = dialogue;
                break;
            }
        }

        return result;
    }
}
