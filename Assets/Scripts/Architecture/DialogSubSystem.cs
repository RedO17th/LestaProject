using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[Note] Если вынести инициализацию "диалоговых энкаунтеров" в данную подсистему,
//как функционал, то уже она будет решать, есть ли эти самые
//сущности внутри определенного quest'a и выполнять определенную логику

public class DialogSubSystem : BaseSubSystem
{
    [SerializeField] private DialogueController _dialogueController;

    //[SerializeField] private List<DialogContainer> _dialogContainers;

    private QuestSubSystem _questSubSystem = null;
    private DiceTwentySubSystem _diceTwentySubSystem = null;

    private CharactersContainer _characters = null;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);
    }

    public override void Prepare()
    {
        //_questSubSystem = _projectSystem.GetSubSystemByType(typeof(QuestSubSystem)) as QuestSubSystem;
        //_questSubSystem.OnQuestWillActivated += InitializeDialogEncountersByQuestType;

        _diceTwentySubSystem = _projectSystem.GetSubSystemByType(typeof(DiceTwentySubSystem)) as DiceTwentySubSystem;

        var settingsSystem = _projectSystem.GetSubSystemByType(typeof(SettingsSubSystem)) as SettingsSubSystem;
        _characters = settingsSystem?.GetDataContainerByType(typeof(CharactersContainer)) as CharactersContainer;

        _dialogueController.Initialize(this);
    }

    //private void InitializeDialogEncountersByQuestType(Type questType)
    //{
    //    var currentDialogContainer = GetDialogContainerByQuestType(questType);

    //    InitializeDialogEncounters(currentDialogContainer);
    //}

    //private DialogContainer GetDialogContainerByQuestType(Type questType)
    //{
    //    DialogContainer currentDialogContainer = null;

    //    foreach (var container in _dialogContainers)
    //    {
    //        if (container.IsEqual(questType))
    //        {
    //            currentDialogContainer = container;
    //            break;
    //        }
    //    }

    //    return currentDialogContainer;
    //}

    //private void InitializeDialogEncounters(DialogContainer dialogContainer)
    //{
    //    var dialogEncounterPair = dialogContainer.GetDialogEncounters();

    //    foreach (var pair in dialogEncounterPair)
    //    {
    //        var encounter = pair.Encounter;
    //        var dialog = pair.Dialog;

    //        if (encounter is IDialogable dEncounter)
    //        {
    //            dEncounter.InitializeDialogable(this);
    //            dEncounter.SetDialog(dialog);
    //        }
    //    }
    //}

    public void StartNewDialog(TextAsset newStory)
    {
        _dialogueController.StartStory(newStory);
    }

    public CharacterDialogueInfo GetCharacterInfo(string tag)
    {
        return _characters.GetCharacterByTag(tag);
    }

    public bool Check(string tag)
    {
        var parts = tag.Split(".");

        if (parts.Length > 2)
        {
            if (parts[0].ToLower().Equals("checkcharacteristic"))
            {
                if (int.TryParse(parts[2], out int difficult) == false)
                    throw new Exception("Wrong format of checking difficult");

                return _diceTwentySubSystem.CheckByCharacteristicName(parts[1], difficult);
            }

            if (parts[0].ToLower().Equals("checkskill"))
            {
                if (int.TryParse(parts[2], out int difficult) == false)
                    throw new Exception("Wrong format of checking difficult");

                return _diceTwentySubSystem.CheckBySkillName(parts[1], difficult);
            }
        }

        throw new Exception("Wrong format of checking tag");
    }

    public void AddObjectToInventory(string tag)
    {
        var nameObject = tag["NewObject.".Length..];

        if (string.IsNullOrWhiteSpace(nameObject) == false)
        {
            //TODO: real adding object to inventory
            Debug.Log($"Добавлен предмет: {nameObject}");
        }
        else
            throw new Exception("Empty name of adding object to inventory");
    }

    public void ActivateQuest(string tag)
    {
        var nameQuest = tag["Quest.".Length..];

        if (string.IsNullOrWhiteSpace(nameQuest) == false)
        {
            //TODO: real activating quest
            Debug.Log($"Активирован квест: {nameQuest}");
        }
        else
            throw new Exception("Empty name of activated quest");
    }

    public void AddNoteToJournal(string tag)
    {
        var nameNote = tag["Note.".Length..];

        if (string.IsNullOrWhiteSpace(nameNote) == false)
        {
            //TODO: real add note to journal
            Debug.Log($"Добавлена запись: {nameNote}");
        }
        else
            throw new Exception("Empty name of note");
    }

    public void AddDebuf(string tag)
    {
        var parts = tag.Split(".");

        if (parts.Length > 2)
        {
            //TODO: real debuffes
            Debug.Log($"Наложен дебаф {parts[2]} на персонажа {parts[1]}");
        }
        else
            throw new Exception("Wrong format of debuf tag");
    }

    public override void StartSystem() { }

    public override void Clear()
    {
        //_questSubSystem.OnQuestWillActivated -= InitializeDialogEncountersByQuestType;
        _questSubSystem = null;
    }

}

//[System.Serializable]
//public class DialogContainer
//{
//    [SerializeField] private BaseQuest _quest = null;
//    [SerializeField] private List<DialogEncounter> _dialogEncounter;

//    public bool IsEqual(Type questType) => _quest.Type == questType;

//    public List<DialogEncounter> GetDialogEncounters()
//    {
//        List<DialogEncounter> list = new List<DialogEncounter>();

//        foreach (var encounter in _dialogEncounter)
//            list.Add(encounter);

//        return list;
//    }

//}

[System.Serializable]
public class DialogEncounter
{
    [SerializeField] private BaseEncounter _encounter = null;
    [SerializeField] private BaseDialog _dialog = null;

    public BaseEncounter Encounter => _encounter;
    public BaseDialog Dialog => _dialog;
}