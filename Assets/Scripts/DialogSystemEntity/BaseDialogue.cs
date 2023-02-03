using System;
using UnityEngine;

public class BaseDialogue : MonoBehaviour
{
    [SerializeField] protected TextAsset _dialogueFile = null;
    [SerializeField] protected BaseDialogueResult _dialogueResult = null; 

    public event Action OnStarted;
    public event Action OnEnded;

    public string Name => _dialogueFile.name;
    public TextAsset File => _dialogueFile;

    protected IDialogableEncounter _encounter = null;

    public virtual void Initialize(IDialogableEncounter encounter)
    {
        _encounter = encounter;

        _dialogueResult?.Initialize(this, _encounter);
    }

    public virtual void ProcessCommandViaTag(string tag) { }

    public virtual void InvokeResult()
    {
        if (_dialogueResult == null)
        {
            Debug.Log($"BaseDialogue.InvokeResult: result is absent");
            return;
        }

        _dialogueResult.Invoke();
    }

    public virtual void End()
    {
        _dialogueResult?.Cancel();

        _encounter = null;

        OnEnded?.Invoke();
    }
}
