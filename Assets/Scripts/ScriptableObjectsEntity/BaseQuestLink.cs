using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestLink", menuName = "ScriptableObjects/Links/QuestLink")]
public class BaseQuestLink : ScriptableObject
{
    [SerializeField] private bool _isCompleted = false;

    public event Action<BaseQuestLink> OnCompleted;

    public bool IsCompleted => _isCompleted;

    public virtual void Complete()
    {
        _isCompleted = true;

        OnCompleted?.Invoke(this);
    }

    public virtual void UsualCompletion()
    {
        _isCompleted = true;
    }
}

