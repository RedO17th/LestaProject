using Ink.Runtime;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private Choice _choice = null;
    private Story _story = null;

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
