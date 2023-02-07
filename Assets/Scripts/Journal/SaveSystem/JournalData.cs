[System.Serializable]
public class JournalData
{
    public NoteUIData[] NotesUIData { get; private set; }

    public JournalData(NoteUI[] notesUI)
    {
        NotesUIData = new NoteUIData[notesUI.Length];

        for (int i = 0; i < notesUI.Length; i++)
        {
            NotesUIData[i].Note = notesUI[i].Note;
            NotesUIData[i].IsNew = notesUI[i].IsNew;
            NotesUIData[i].IsSelected = notesUI[i].IsSelected;
            NotesUIData[i].IsSelectable = notesUI[i].IsSelectable;
        }
    }
}


[System.Serializable]
public struct NoteUIData
{
    public bool IsNew;
    public bool IsSelected;
    public bool IsSelectable;
    public INote Note;
}
