using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObjects/Container/DialogueData")]
public class DialogueDataContainer : BaseDataContainer
{
    [SerializeField] private TextAsset[] _dialogues;

    public TextAsset GetDialogueByName(string name)
    {
        TextAsset result = null;
        foreach (var dialogue in _dialogues)
        {
            if(dialogue.name.Equals(name))
            {
                result = dialogue;
                break;
            }
        }

        return result;
    }
}
