using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JournalPanel : MonoBehaviour
{
    [SerializeField] private NoteInfoPanel _infoPanel;
    [SerializeField] private GameObject _listPanel;

    public void OpenInfoPanel(INote note)
    {
        _listPanel.SetActive(false);
        _infoPanel.gameObject.SetActive(true);
       
        _infoPanel.SetNoteInfo(note);
    }

    public void OpenListPanel()
    {
        _listPanel.SetActive(true);
        _infoPanel.gameObject.SetActive(false);
    }
}
