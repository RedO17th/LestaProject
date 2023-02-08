using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LoadNotesFromExcel : MonoBehaviour
{
    public TextAsset textAsset;


    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.J))
    //    {
    //        ReadCSV();
    //    }
    //}
    public void ReadCSV()
    {
        string[] data = textAsset.text.Split(new string[] { "\n" }, System.StringSplitOptions.None);

        string noteId;
        string noteName;
        string noteDescription;

        foreach (string note in data)
        {
            string[] noteData = note.Split(new string[] { "\t" }, System.StringSplitOptions.None);
            if (noteData.Length == 3)
            {
                string[] id = noteData[0].Split(new string[] {"."}, System.StringSplitOptions.None);
                noteId = id[id.Length - 1];
                noteName = noteData[1];
                noteDescription = noteData[2];

                DiaryNote diaryNote = ScriptableObject.CreateInstance(typeof(DiaryNote)) as DiaryNote;

                diaryNote.SetData(noteId, noteName, noteDescription);

                AssetDatabase.CreateAsset(diaryNote, $"Assets/Resources/DiaryNoteDB/DiaryNotes/{noteId}.asset");
            }
        }
        AssetDatabase.SaveAssets();

    }
}
