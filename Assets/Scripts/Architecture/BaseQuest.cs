using System;
using UnityEngine;

public abstract class BaseQuest : MonoBehaviour
{
    public event Action OnCompleted;

    public bool IsCompleted { get; protected set; } = false;

    protected QuestSubSystem _questSubSystem = null;

    public virtual void SetCompletedState() => IsCompleted = true;
    public virtual void SetUnCompletedState() => IsCompleted = false;

    public virtual void Initialize(QuestSubSystem system)
    {
        _questSubSystem = system;
    }

    public virtual void Prepare() { }
    public abstract void Launch();

    protected virtual void CheckCompliting()
    {
        if (CheckConditionOfCompliting())
        {
            OnCompleted?.Invoke();
        }
    }

    protected virtual bool CheckConditionOfCompliting() { return false; }
    public abstract void Complete();
}
