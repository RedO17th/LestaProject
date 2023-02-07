[System.Serializable]
public class PlayerJournalData
{
    public JournalData ActiveJournal { get; private set; }
    public JournalData CompleteJournal { get; private set; }
    public JournalData DiaryJournal { get; private set; }

    public PlayerJournalData(JournalData activeJournal, JournalData completeJournal, JournalData diaryJournal)
    {
        ActiveJournal = activeJournal;
        CompleteJournal = completeJournal;
        DiaryJournal = diaryJournal;
    }
}
