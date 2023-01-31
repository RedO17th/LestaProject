using UnityEngine;
using UnityEngine.UI;
using System;
using Ink.Runtime;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class DialogueController : MonoBehaviour
{
    //[SerializeField] private TextAsset inkJSONAsset = null;

    [SerializeField] private GameObject _dialogueScreen = null;

    [Header("Speaker")]
    [SerializeField] private Text _speaker = null;
    [SerializeField] private Image _portrait = null;
    [SerializeField] private Image _portraitShadow = null;

    [Header("Replica")]
    [SerializeField] private Text _replica = null;

    [Header("Tisha")]
    [SerializeField] private Image _tishaShadow = null;

    [Header("Buttons")]
    [SerializeField] private ChoiceButton[] _choiceButtons = null;
    [SerializeField] private ChoiceButton _nextButton = null;

    public static event Action<Story> OnCreateStory;

    private DialogSubSystem _dialogSubSystem;

    private Story _story;

    public void Initialize(DialogSubSystem dialogSubSystem)
    {
        _dialogSubSystem = dialogSubSystem;

        foreach (var button in _choiceButtons)
        {
            button.OnClickEvent += RefreshView;
        }
        _nextButton.OnClickEvent += RefreshView;
    }

    // Creates a new Story object with the compiled story which we can then play!
    public void StartStory(TextAsset newStory)
    {
        _story = new Story(newStory.text);
        if (OnCreateStory != null) OnCreateStory(_story);

        foreach (var button in _choiceButtons)
        {
            button.SetStory(_story);
        }
        _nextButton.SetStory(_story);

        _dialogueScreen.SetActive(true);

        RefreshView();
    }

    [ContextMenu("Switch")]
    private void SwitchCheckResult()
    {
        _story.variablesState.SetGlobal("CheckResult", Value.Create(true));
        _story.variablesState.SetGlobal("CheckResultStr", Value.Create(true));
    }

    // This is the main function called every time the story changes. It does a few things:
    // Destroys all the old content and choices.
    // Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
    void RefreshView()
    {
        // Read all the content until we can't continue any more
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
            _dialogueScreen.SetActive(false);

        // If we've read all the content and there's no choices, the story is finished!
        //else {
        //	Button choice = CreateChoiceView("End of story.\nRestart?");
        //	choice.onClick.AddListener(delegate{
        //		StartStory();
        //	});
        //}
    }

    private void SetReplica()
    {
        // Continue gets the next line of the story
        string text = _story.Continue();
        // This removes any white space from the text.
        text = text.Trim();
        // Display the text on screen!
        CreateContentView(text);

        foreach (var tag in _story.currentTags)
        {
            if (tag.StartsWith("Speaker."))
            {
                ConfigurateSpeaker(tag["Speaker.".Length..]);
            }
            else if (tag.StartsWith("Check"))
            {
                Checking(tag);
            }
        }
    }

    private void ConfigureChoices()
    {
        _nextButton.Interactable = (_story.currentChoices.Count == 1);

        if (_story.currentChoices.Count == 1)
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
        //string name = tag["Speaker.".Length..];

        var character = _dialogSubSystem.GetCharacterInfo(tag);

        _speaker.text = character.Name;

        if (tag.Equals("Tisha"))
        {
            _tishaShadow.enabled = false;
            _portraitShadow.enabled = true;
        }
        else
        {
            _tishaShadow.enabled = true;
            _portraitShadow.enabled = false;

            _portrait.sprite = character.Portreit;
        }
    }

    private void Checking(string tag)
    {
        bool result = _dialogSubSystem.Check(tag);
        _story.variablesState.SetGlobal("CheckResult", Value.Create(result));

        string resultStr = result ? "[УСПЕХ]" : "[ПРОВАЛ]";
        _story.variablesState.SetGlobal("CheckResultStr", Value.Create(resultStr));
    }

    // Creates a textbox showing the the line of text
    void CreateContentView(string text)
    {
        //Text storyText = Instantiate(textPrefab) as Text;
        //storyText.text = text;
        //storyText.transform.SetParent(canvas.transform, false);
        _replica.text = text;
    }
}
