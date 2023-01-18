using System;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class QuestAndDialogs
{
    [SerializeField] private BaseQuest _quest = null;
    [SerializeField] private List<BaseDialog> _dialogs;

    public Type QuestType => _quest.GetType();

    public void GetDialogs(ref List<BaseDialog> newList)
    {
        foreach (var dialog in _dialogs)
            newList.Add(dialog);
    }
}

public class BaseDialogController
{ 
    protected DialogSubSystem _dialogSubSystem = null;
    protected QuestAndDialogsContaner _dialogContaner = null;

    protected List<BaseDialog> _currentDialogs = new List<BaseDialog>();

    public BaseDialogController(DialogSubSystem system)
    {
        _dialogSubSystem = system;
        _dialogSubSystem.OnQuestActivated += SetCurrentDialogsByQuest;
    }

    public virtual void SetDialogContainer(QuestAndDialogsContaner contaner)
    {
        _dialogContaner = contaner;
    }

    protected virtual void SetCurrentDialogsByQuest(BaseQuest quest)
    {
        Debug.Log($"BaseDialogController: Quest is { quest.GetType() } ");

        _currentDialogs.Clear();
        _currentDialogs = _dialogContaner.GetDialogsByQuestType(quest.Type);
    }

    public virtual void Clear()
    {
        _dialogSubSystem.OnQuestActivated -= SetCurrentDialogsByQuest;
        _dialogSubSystem = null;
    }
}
