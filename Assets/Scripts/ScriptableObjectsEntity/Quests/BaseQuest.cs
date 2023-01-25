using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestState { None = -1, Opened, Closed, Activated, InProgress, Complete, Failed }

[CreateAssetMenu]
public class BaseQuest : ScriptableObject
{
    [SerializeField] protected QuestState _state = QuestState.Closed;

    [SerializeField] protected string _idName = string.Empty;

    [SerializeField] protected string _name = string.Empty;
    [SerializeField] protected string _description = string.Empty;

    public string IDName => _idName;

    protected QuestSubSystem _questSubSystem = null;

    public virtual void Initialize(QuestSubSystem system) { }

    public bool StateIs(QuestState checkableState)
    {
        return _state == checkableState;
    }

    public virtual void Prepare() { Debug.Log($"BaseQuest.Prepare"); }
    public virtual void Activate() { Debug.Log($"BaseQuest.Activate"); }

    protected virtual void Complete() { }
    protected virtual void CheckCompliting() { }
    protected virtual bool CheckConditionOfCompliting() { return false; }

    public virtual void Dectivate() { }
    protected virtual void Clear() { }
}
