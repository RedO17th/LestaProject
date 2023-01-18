using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestAndDialogs", menuName = "ScriptableObjects/Container/QuestAndDialogs")]
public class QuestAndDialogsContaner : BaseDataContainer
{
    [SerializeField] private List<QuestAndDialogs> _questAndDialogs;

    public List<BaseDialog> GetDialogsByQuestType(Type questType)
    {
        List<BaseDialog> dialogs = new List<BaseDialog>();

        foreach (var container in _questAndDialogs)
        {
            if (container.QuestType == questType)
            { 
                container.GetDialogs(ref dialogs);
                break;
            }
        }

        return dialogs;
    }
}