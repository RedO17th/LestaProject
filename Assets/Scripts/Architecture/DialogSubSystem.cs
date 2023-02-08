using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSubSystem : BaseSubSystem
{
    [SerializeField] private DialogueSceneController _dialogueController;

    private DiceTwentySubSystem _diceTwentySubSystem = null;

    private CharactersContainer _charactersData = null;
    private DialogueDataContainer _dialogueData = null;

    private DialogContext _currentContext = null;

    public static event Action OnDialogScreenCalled;
    public static event Action OnExitFromDialogScreenCalled;

    public event Action<object, INote> OnAddNote;

    public void Initialize(ProjectSystem system) => base.Initialize();

    public BaseDialogue GetDialogueByName(string name)
    {
        return _dialogueData.GetDialogueByName(name);
    }

    public override void Prepare()
    {
        _dialogueController.Initialize(this);

        _diceTwentySubSystem = ProjectSystem.GetSubSystem<DiceTwentySubSystem>();

        var settingsSystem = ProjectSystem.GetSubSystem<SettingsSubSystem>();
        
        _charactersData = settingsSystem?.GetDataContainerByType(typeof(CharactersContainer)) as CharactersContainer;
        _dialogueData = settingsSystem?.GetDataContainerByType(typeof(DialogueDataContainer)) as DialogueDataContainer;

        ProjectBus.Instance.OnDialogContextSignal += ProcessSignal;
    }

    public override void StartSystem() { }

    public void Start()
    {
        DialogueSceneController.OnDialogueEnd += HandleOnDialogueEnd;
        DialogueSceneController.OnDialogueStart += HandleOnDialogueStart;
    }

    public void HandleOnDialogueStart()
    {
        EventSystem.UIEvents.InvokeOnDialogueMenuCalled();
    }

    public void HandleOnDialogueEnd()
    {

        EventSystem.UIEvents.InvokeOnExitFromDialogueMenuCalled();
    }


    private void ProcessSignal(DialogContext context)
    {
        _currentContext = context;

        ProcessContext();
    }
    private void ProcessContext()
    {
        switch (_currentContext.Command)
        {
            case DialogueCommand.None:
                break;
            case DialogueCommand.Activate:
                {
                    ActivateDialogue();
                    break;
                }
        }
    }

    private void ActivateDialogue()
    {
        var dialogue = GetDialogueByName(_currentContext.IDName);

        StartNewDialog(dialogue);
    }

    public void StartNewDialog(BaseDialogue newStory)
    {
        _dialogueController.StartStory(newStory);
    }

    public CharacterDialogueInfo GetCharacterInfo(string tag)
    {
        return _charactersData.GetCharacterByTag(tag);
    }

    public bool Check(string tag)
    {
        bool result = false;

        var parts = tag.Split(".");

        if (parts.Length > 2)
        {
            if (parts[0].ToLower().Equals("checkcharacteristic"))
            {
                if (int.TryParse(parts[2], out int difficult) == false)
                    throw new Exception("Wrong format of checking difficult");

                result = _diceTwentySubSystem.CheckByCharacteristicName(parts[1], difficult);
            }

            if (parts[0].ToLower().Equals("checkskill"))
            {
                if (int.TryParse(parts[2], out int difficult) == false)
                    throw new Exception("Wrong format of checking difficult");

                result = _diceTwentySubSystem.CheckBySkillName(parts[1], difficult);
            }
        }

        return result;
    }

    public void AddObjectToInventory(string tag)
    {
        var nameObject = tag["NewObject.".Length..];

        if (string.IsNullOrWhiteSpace(nameObject) == false)
        {
            //TODO: real adding object to inventory
            Debug.Log($"Добавлен предмет: {nameObject}");
        }
    }

    public void ActivateQuest(string tag)
    {
        var nameQuest = tag["Quest.".Length..];

        if (string.IsNullOrWhiteSpace(nameQuest) == false)
        {
            CreateAndSendQuestContext(nameQuest);
        }
    }

    private void CreateAndSendQuestContext(string nameQuest)
    {
        var context = new QuestContext();
            context.SetCommand(QuestCommand.Activate);
            context.SetID(nameQuest);

        ProjectBus.Instance.SendSignalByContext(context);
    }

    public void AddNoteToJournal(string tag)
    {
        var noteID = tag["Note.".Length..];

        if (string.IsNullOrWhiteSpace(noteID) == false)
        {
            //TODO: real add note to journal
            SettingsSubSystem settingsSubSystem = ProjectSystem.GetSubSystem<SettingsSubSystem>();
            var noteDB = settingsSubSystem.GetDataContainerByType(typeof(DiaryNoteDB)) as DiaryNoteDB;
            INote note = noteDB.GetNote(noteID);
            OnAddNote?.Invoke(this, note);

            Debug.Log($"Добавлена запись: {noteID}");
        }
    }

    public void AddDebuf(string tag)
    {
        var parts = tag.Split(".");

        if (parts.Length > 2)
        {
            //TODO: real debuffes
            Debug.Log($"Наложен дебаф {parts[2]} на персонажа {parts[1]}");
        }
    }

    public override void Clear()
    {
        ProjectBus.Instance.OnDialogContextSignal -= ProcessSignal;
    }
}
