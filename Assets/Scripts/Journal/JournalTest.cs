using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalTest : MonoBehaviour
{
    [SerializeField] private TestQuestForJournal _testQuest;
    [SerializeField] private TestDiaryNote _testNote;

    public event Action<object, INote> OnQuestActivate;
    public event Action<object, INote> OnQuestComplete;
    public event Action<object, INote> OnAddNoteToDiary;
    public event Action OnSaveJournal;
    public event Action OnLoadJournals;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            ActivateQuest();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CompleteQuest();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            AddNoteToDiary();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //_notebookPanel.TurnOnPanels();
            OnSaveJournal?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //_notebookPanel.TurnOnPanels();
            OnLoadJournals?.Invoke();
        }



    }

    public void ActivateQuest()
    {
        OnQuestActivate?.Invoke(this, _testQuest);
    }
    public void CompleteQuest()
    {
        OnQuestComplete?.Invoke(this, _testQuest);
    }

    public void AddNoteToDiary()
    {
        OnAddNoteToDiary?.Invoke(this, _testNote);
    }

}
