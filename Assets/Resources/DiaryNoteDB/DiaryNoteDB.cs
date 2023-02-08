using UnityEngine;

[CreateAssetMenu(fileName = "DiaryNoteDB", menuName = "DB/Journal/Create New DiaryNoteDB")]
public class DiaryNoteDB : BaseDataContainer
{
    public DiaryNote[] DiaryNotes;

    public INote GetNote(string NoteId)
    {
        foreach(var note in DiaryNotes)
        {
            if(note.Id == NoteId)
            {
                return note;
            }
        }
        return null;
    }
}
