using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialogueInvoker : IActivatable
{
    string DialogueName { get; }
}

public class DialogueInvoker : BaseContextInvoker, IDialogueInvoker
{
    [SerializeField] protected string _dialogueName = string.Empty;

    public string DialogueName => _dialogueName;

    public virtual void Activate() { }
    public virtual void Deactivate() { }
}
