using UnityEngine;

public class BaseDialogueResult : MonoBehaviour
{
    protected BaseDialogue _dialogue = null;
    protected IDialogableEncounter _encounter = null;

    protected bool _isInvoked = false;

    public virtual void Initialize(BaseDialogue dialogue, IDialogableEncounter encounter)
    {
        _dialogue = dialogue;
        _encounter = encounter;

        _isInvoked = false;
    }

    public virtual void Invoke()
    {
        if (_isInvoked == false)
        {
            _isInvoked = true;

            ProcessInvoke();
        }
    }

    protected virtual void ProcessInvoke() { }

    public virtual void Cancel()
    {
        _encounter = null;
        _dialogue = null;
    }
}