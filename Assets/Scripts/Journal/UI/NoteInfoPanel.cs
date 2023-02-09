using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoteInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _content;

    public virtual void SetNoteInfo(INote note)
    {
        _header.text = note.Header;

        string[] content = note.Content.Split(new string[] { "\\n" }, System.StringSplitOptions.None);

        string contentWithN = "";
        foreach (string line in content)
        {
            contentWithN += line + "\n";
        }

        _content.text = contentWithN;
    
    }
}
