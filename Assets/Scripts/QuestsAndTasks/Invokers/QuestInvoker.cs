using UnityEngine;

public interface IQuestInvoker : IActivatable
{
    string QuestID { get; }
}

public class QuestInvoker : BaseContextInvoker, IQuestInvoker
{
    [SerializeField] protected string _questID = string.Empty;

    public string QuestID => _questID;

    public virtual void Activate() { }
    public virtual void Deactivate() { }
}