using System;
using UnityEngine;

public enum DialogueCommand { None = -1, Activate }

public class BaseDialogue : MonoBehaviour
{
    [SerializeField] protected TextAsset _dialogueFile = null;
    [SerializeField] protected BaseDialogueResult _dialogueResult = null; 

    //public event Action OnStarted;
    //public event Action OnEnded;

    public string Name => _dialogueFile.name;
    public TextAsset File => _dialogueFile;

    public bool CorrectCompletion{ get; protected set; } = false;

    public void SetComplitionState(bool state = true) => CorrectCompletion = state;
}
