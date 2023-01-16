using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseQuest : ScriptableObject
{
    [SerializeField] protected string _name = string.Empty;
    [SerializeField] protected bool _isCompleted = false;
    [TextArea]
    [SerializeField] protected string _description = string.Empty;

    [Header("Quest links")]
    [SerializeField] protected List<BaseQuestLink> _links;

    public event Action OnCompleted;

    public bool IsCompleted => _isCompleted;

    protected QuestSubSystem _questSubSystem = null;

    public virtual void SetCompletedState() => _isCompleted = true;
    public virtual void SetUnCompletedState() => _isCompleted = false;

    public virtual void Initialize(QuestSubSystem system)
    {
        _questSubSystem = system;
    }

    public virtual void Prepare() 
    {
        InitializeLinks();
    }

    protected virtual void InitializeLinks()
    {
        foreach (var link in _links)
            link.OnCompleted += CheckCompliting;
    }

    public virtual void Launch() { }

    protected virtual void CheckCompliting(BaseQuestLink link)
    {
        link.OnCompleted -= CheckCompliting;

        if (CheckConditionOfCompliting())
        {
            OnCompleted?.Invoke();
        }
    }

    protected virtual bool CheckConditionOfCompliting()
    {
        bool result = true;

        foreach (var link in _links)
        {
            if (link.IsCompleted == false)
                result = false;
        }

        return result;
    }

    public virtual void Complete() 
    {
        DeactivateQuestLinks();
    }

    protected virtual void DeactivateQuestLinks()
    {
        foreach (var link in _links)
            link.UsualCompletion();
    }
}
