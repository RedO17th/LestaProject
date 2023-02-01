using System;
using UnityEngine;

[System.Serializable]
public class BaseDialogue
{
    [SerializeField] protected TextAsset _dialogueFile = null;

    public event Action OnStarted;
    public event Action OnEnded;

    public string Name => _dialogueFile.name;
    public TextAsset File => _dialogueFile;

    public void End() => OnEnded?.Invoke();
}
