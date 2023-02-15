using UnityEngine;
using UnityEngine.UI;
using System;
using Ink.Runtime;
using TMPro;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class DialogueSceneController : MonoBehaviour
{
    #region UIComponents
    [SerializeField] private GameObject _dialogueScreen = null;

    [Header("Speaker")]
    [SerializeField] private TextMeshProUGUI _speakerName = null;
    [SerializeField] private Image _speakerPortrait = null;
    [SerializeField] private Image _speakerShadow = null;

    [Header("Replica")]
    [SerializeField] private TextMeshProUGUI _replica = null;

    [Header("Tisha")]
    [SerializeField] private Image _tishaShadow = null;

    [Header("Buttons")]
    [SerializeField] private ChoiceButton[] _choiceButtons = null;
    [SerializeField] private ChoiceButton _nextButton = null;
    #endregion

    //Мазанов А. - Для чего нужен этот ивент?
    public static event Action<Story> OnCreateStory;

    //Мазанов А.
    public static event Action OnDialogueStart;
    public static event Action OnDialogueEnd;

    private DialogSubSystem _dialogSubSystem = null;

    private BaseDialogue _currentDialogue = null;
    private Story _story = null;

    public void Initialize(DialogSubSystem dialogSubSystem)
    {
        _dialogSubSystem = dialogSubSystem;

        foreach (var button in _choiceButtons)
            button.OnClickEvent += RefreshView;

        _nextButton.OnClickEvent += RefreshView;
    }

    // Creates a new Story object with the compiled story which we can then play!
    public void StartStory(BaseDialogue dialogue)
    {
        //Мазанов А.
        OnDialogueStart?.Invoke();

        _currentDialogue = dialogue;

        _story = new Story(_currentDialogue.File.text);

        OnCreateStory?.Invoke(_story);

        foreach (var button in _choiceButtons)
            button.SetStory(_story);

        _nextButton.SetStory(_story);

        //_dialogueScreen.SetActive(true);

        RefreshView();
    }

    void RefreshView()
    {
        while (_story.canContinue)
        {
            SetReplica();
        }

        // Display all the choices, if there are any!
        if (_story.currentChoices.Count > 0)
        {
            ConfigureChoices();
        }
        else
        {
            OnDialogueEnd.Invoke();
            //_dialogueScreen.SetActive(false);

            _currentDialogue.InvokeResult();
            _currentDialogue.End();
            _currentDialogue = null;

            //[?] Нужно ли ее обнулять...
            //_story = null;
        }
    }

    private void SetReplica()
    {
        string text = _story.Continue();
        _replica.text = text.Trim();

        foreach (var tag in _story.currentTags)
        {
            if (tag.StartsWith("Speaker."))
            {
                ConfigurateSpeaker(tag);
            }
            else if (tag.StartsWith("Check"))
            {
                Checking(tag);
            }
            else if(tag.StartsWith("NewObject"))
            {
                AddObjectToInventory(tag);
            }
            else if(tag.StartsWith("Quest"))
            {
                ActivateQuest(tag);
            }
            else if(tag.StartsWith("Note"))
            {
                AddNoteToJournal(tag);
            }
            else if(tag.StartsWith("Debuff"))
            {
                AddDebuf(tag);
            }
        }
    }

    void CreateContentView(string text)
    {
        _replica.text = text;
    }

    private void Checking(string tag)
    {
        bool result = _dialogSubSystem.Check(tag);
        _story.variablesState.SetGlobal("CheckResult", Value.Create(result));

        string resultStr = result ? "[УСПЕХ]" : "[ПРОВАЛ]";
        _story.variablesState.SetGlobal("CheckResultStr", Value.Create(resultStr));
    }


    private void ConfigureChoices()
    {
        _nextButton.Interactable = (_story.currentChoices.Count == 1);

        if (_story.currentChoices.Count == 1 && _story.currentChoices[0].text==">>")
        {
            _nextButton.SetNewChoice(_story.currentChoices[0]);

            for (int i = 0; i < _choiceButtons.Length; i++)
            {
                _choiceButtons[i].gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < _choiceButtons.Length; i++)
            {
                if (i >= _story.currentChoices.Count)
                {
                    _choiceButtons[i].gameObject.SetActive(false);
                    continue;
                }

                _choiceButtons[i].gameObject.SetActive(true);
                _choiceButtons[i].SetNewChoice(_story.currentChoices[i]);
            }
        }
    }
	
    private void ConfigurateSpeaker(string tag)
    {
        string name = tag["Speaker.".Length..];

        var character = _dialogSubSystem.GetCharacterInfo(name);

        _speakerName.text = character.Name;

        if (name.Equals("Tisha"))
        {
            _tishaShadow.enabled = false;
            _speakerShadow.enabled = true;
        }
        else
        {
            _tishaShadow.enabled = true;
            _speakerShadow.enabled = false;

            _speakerPortrait.sprite = character.Portreit;
        }
    }

    private void AddObjectToInventory(string tag)
    {
        _dialogSubSystem.AddObjectToInventory(tag);
    }

    private void ActivateQuest(string tag)
    {
        _dialogSubSystem.ActivateQuest(tag);
    }

    private void AddNoteToJournal(string tag)
    {
        _dialogSubSystem.AddNoteToJournal(tag);
    }
   
    private void AddDebuf(string tag)
    {
        _dialogSubSystem.AddDebuf(tag);
    }
}
