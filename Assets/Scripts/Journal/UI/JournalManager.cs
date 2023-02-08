using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalManager : MonoBehaviour
{ 
    [SerializeField] private JournalUI _activeQuestsJournal;
    [SerializeField] private JournalUI _completeQuestsJournal;
    [SerializeField] private JournalUI _diaryJournal;

    private QuestSubSystem _questSubSystem;
    //[SerializeField] private JournalTest JournalTest;

    private void OnEnable()
    {
        //JournalTest.OnQuestActivate += QuestActivated;
        //JournalTest.OnQuestComplete += QuestCompleted;
        //JournalTest.OnAddNoteToDiary += AddNoteToDiary;

        //JournalTest.OnSaveJournal += SaveJournalsToGameData;
        //JournalTest.OnLoadJournals += LoadJournalsFromGameData;
    }

    private void Start()
    {
        _questSubSystem = ProjectSystem.GetSubSystem<QuestSubSystem>();

        _questSubSystem.OnQuestActivated += QuestActivated;
        _questSubSystem.OnQuestCompleted += QuestCompleted;

        DialogSubSystem dialogSubSystem = ProjectSystem.GetSubSystem<DialogSubSystem>();

        dialogSubSystem.OnAddNote += AddNoteToDiary;
    }

    public void QuestActivated(object sender, INote quest)
    {
        _activeQuestsJournal.AddNote(sender, quest, true, true);
    }

    public void QuestCompleted(object sender, INote quest)
    {
        NoteUI noteUI = _activeQuestsJournal.GetNoteUIByNote(sender, quest);

        if (noteUI == null)
        {
            Debug.Log($"Не удалось найти в журнале квест {quest.Header}");
            return;
        }

        noteUI.IsSelected = false;
        noteUI.IsSelectable = false;

        _completeQuestsJournal.AddNote(sender, quest, noteUI.IsNew);
        _activeQuestsJournal.RemoveNoteUI(sender, noteUI);
    }

    public void AddNoteToDiary(object sender, INote note)
    {
        _diaryJournal.AddNote(sender, note);
    }

    public void SaveJournalsToGameData()
    {
        JournalData activeQuestsJournalData = _activeQuestsJournal.GetJournalUIData();
        JournalData completeQuestsJournalData = _completeQuestsJournal.GetJournalUIData();
        JournalData diaryJournalData = _diaryJournal.GetJournalUIData();

        PlayerJournalData playerJournalData = new PlayerJournalData(activeQuestsJournalData, completeQuestsJournalData, diaryJournalData);

        GameData.Instance.AddPlayerJournalData(playerJournalData);
    }

    public void LoadJournalsFromGameData()
    {
        _activeQuestsJournal.LoadJournalUIFromData(this, GameData.Instance.PlayerJournalData.ActiveJournal);
        _completeQuestsJournal.LoadJournalUIFromData(this, GameData.Instance.PlayerJournalData.CompleteJournal);
        _diaryJournal.LoadJournalUIFromData(this, GameData.Instance.PlayerJournalData.DiaryJournal);
    }

}
