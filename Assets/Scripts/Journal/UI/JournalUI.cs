using System.Collections.Generic;
using UnityEngine;

public class JournalUI : MonoBehaviour
{ 
    [SerializeField] private NoteUI _noteUIPrefab;
    [SerializeField] private Transform _content;
    [SerializeField] private JournalPanel _journalPanel;

    private List<NoteUI> _notesUI = new List<NoteUI>();
    public List<NoteUI> NotesUI => _notesUI;

    public void AddNote(object sender, INote note, bool isNew = true, bool isSelectable = false, bool isSelected = false)
    {
        CreateNoteUI(sender, note, isNew, isSelectable, isSelected);
    }

    private void CreateNoteUI(object sender, INote note, bool isNew, bool isSelectable, bool isSelected)
    {
        NoteUI noteUI = Instantiate(_noteUIPrefab, _content);

        noteUI.IsNew = isNew;

        noteUI.IsSelected = isSelected;

        noteUI.IsSelectable = isSelectable;

        noteUI.Initialize(note, () => _journalPanel.OpenInfoPanel(note));

        _notesUI.Add(noteUI);
    }

    public bool RemoveNoteUIByNote(object sender, INote note)
    {
        NoteUI noteUI = GetNoteUIByNote(sender, note);
        if (noteUI == null)
            return false;

        RemoveNoteUI(sender, noteUI);
        return true;
    }

    public bool RemoveNoteByID(object sender, string noteId)
    {
        NoteUI noteUI = GetNoteUIByNoteId(sender, noteId);
        if(noteUI == null)
            return false;

        RemoveNoteUI(sender, noteUI);
        return true;
    }
    public void RemoveNoteUI(object sender, NoteUI noteUI)
    {
        _notesUI.Remove(noteUI);
        Destroy(noteUI.gameObject);
    }

    public NoteUI GetNoteUIByNote(object sender, INote note)
    {
        foreach (var noteUI in _notesUI)
        {
            if (noteUI.Note == note)
            {
                return noteUI;
            }
        }
        return null;
    }

    public NoteUI GetNoteUIByNoteId(object sender, string noteId)
    {
        foreach (var noteUI in _notesUI)
        {
            if (noteUI.Note.Id == noteId)
            {
                return noteUI;
            }
        }
        return null;
    }

    public JournalData GetJournalUIData()
    {
        return new JournalData(_notesUI.ToArray());
    }

    public void LoadJournalUIFromData(object sender, JournalData journalUIData)
    {
        Clear();

        foreach (var noteUIdata in journalUIData.NotesUIData)
        {
            CreateNoteUI(sender, noteUIdata.Note, noteUIdata.IsNew, noteUIdata.IsSelectable, noteUIdata.IsSelected);
        }
    }

    private void Clear()
    {
        foreach (var noteUI in _notesUI)
        {
            Destroy(noteUI.gameObject);
        }
        _notesUI.Clear();
    }
}
