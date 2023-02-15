using Ink.Runtime;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    private Choice _choice = null;
    private Story _story = null;

    private Button _button = null;
    private TextMeshProUGUI _buttonCaption = null;

    public event Action OnClickEvent;

    public bool Interactable
    {
        get
        {
            return _button.interactable;
        }
        set
        {
            _button.interactable = value;
        }
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _buttonCaption = _button.GetComponent<TextMeshProUGUI>();
        //Debug.Log(_buttonCaption.text);
    }

    private void Start()
    {
        
    }

    public void SetStory(Story story)
    {
        _story = story;
    }

    public void OnClick()
    {
        _story.ChooseChoiceIndex(_choice.index);
        OnClickEvent?.Invoke();
    }

    public void SetNewChoice(Choice choice)
    {
        _choice = choice;
        if (_buttonCaption != null)
        {
            _buttonCaption.text = "- " + choice.text.Trim();   
        }

    }
}
