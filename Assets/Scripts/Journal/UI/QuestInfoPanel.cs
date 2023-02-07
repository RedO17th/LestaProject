using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestInfoPanel : NoteInfoPanel
{
    [SerializeField] private TextMeshProUGUI _experienceAmountText;
    [SerializeField] private TextMeshProUGUI _moneyAmountText;

    [SerializeField] private UIJournalItem[] _journalItems;

    public override void SetNoteInfo(INote note)
    {
        base.SetNoteInfo(note);
        SetRewardInfo((IQuestNote)note);
    }

    private void SetRewardInfo(IQuestNote questNote)
    {
        _experienceAmountText.text = questNote.Reward.Experience.ToString();
        _moneyAmountText.text = questNote.Reward.Money.ToString();


        foreach (var journalItem in _journalItems)
        {
            journalItem.gameObject.SetActive(false);
        }

        ItemsFactory factory = new ItemsFactory();

        for (int i = 0; i < questNote.Reward.Items.Count; i++)
        {
            IInventoryItem item = factory.SpawnItem(questNote.Reward.Items[i].Info);
            item.State.amount = questNote.Reward.Items[i].Amount;
            _journalItems[i].SetUp(item);
        }
    }
}
