using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[Note] ���� ������� ������������� "���������� �����������" � ������ ����������,
//��� ����������, �� ��� ��� ����� ������, ���� �� ��� �����
//�������� ������ ������������� quest'a � ��������� ������������ ������

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

        if (parts.Length > 0)
        {
            if (parts[0].ToLower().Equals("checkcharacteristic"))
            {
                if (int.TryParse(parts[2], out int difficult) == false)
                    return false;

                return _diceTwentySubSystem.CheckByCharacteristicName(parts[1], difficult);
            }

            if (parts[0].ToLower().Equals("checkskill"))
            {
                if (int.TryParse(parts[2], out int difficult) == false)
                    return false;

                return _diceTwentySubSystem.CheckBySkillName(parts[1], difficult);
            }
        }

        return false;
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