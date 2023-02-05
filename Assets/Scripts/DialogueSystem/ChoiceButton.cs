using Ink.Runtime;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    private Choice _choice = null;
    private Story _story = null;

    private Button _button = null;
    private Text _buttonCaption = null;

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
        _buttonCaption = _button.GetComponentInChildren<Text>();
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
        _buttonCaption.text = choice.text.Trim();
    }
}
