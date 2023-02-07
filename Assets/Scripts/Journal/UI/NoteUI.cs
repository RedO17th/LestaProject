using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class NoteUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private GameObject _attentionImage;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Button _button;

    [SerializeField] private INote _note;

    private UnityAction _actionOnClick;

    public INote Note => _note;

    public bool IsNew = true;
    public bool IsSelected = false;
    public bool IsSelectable = false;

    public void Initialize(INote note, UnityAction actionOnClick)
    {
        SetNote(note);

        _actionOnClick = actionOnClick;
        _button.onClick.AddListener(_actionOnClick);

        if (IsNew)
        {
            _attentionImage.SetActive(true);
            _button.onClick.AddListener(DisableAttentionImage);
        }
        if(IsSelectable)
        {
            _toggle.gameObject.SetActive(true);
            _toggle.isOn = IsSelected;
        }
    }

    private void SetNote(INote note)
    {
        _note = note;
        UpdateNote();
    }

    private void UpdateNote()
    {
        if (_note == null)
            return;

        _header.text = _note.Header;
    }

    private void DisableAttentionImage()
    {
        IsNew = false;
        _attentionImage.SetActive(false);
        _button.onClick.RemoveListener(DisableAttentionImage);
    }

    public void ToggleSelect()
    {
        IsSelected = !IsSelected;
    }
}
