using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//[Note] ≈сли вынести инициализацию "диалоговых энкаунтеров" в данную подсистему,
//как функционал, то уже она будет решать, есть ли эти самые
//сущности внутри определенного quest'a и выполн€ть определенную логику

public class DialogSubSystem : BaseSubSystem
{
    [SerializeField] private List<DialogContainer> _dialogContainers;

    private QuestSubSystem _questSubSystem = null;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);
    }
    public override void Prepare()
    {
        _questSubSystem = _projectSystem.GetSubSystemByType(typeof(QuestSubSystem)) as QuestSubSystem;
        //_questSubSystem.OnQuestWillActivated += InitializeDialogEncountersByQuestType;
    }

    private void InitializeDialogEncountersByQuestType(Type questType)
    {
        var currentDialogContainer = GetDialogContainerByQuestType(questType);

        InitializeDialogEncounters(currentDialogContainer);
    }

    private DialogContainer GetDialogContainerByQuestType(Type questType)
    {
        DialogContainer currentDialogContainer = null;

        foreach (var container in _dialogContainers)
        {
            if (container.IsEqual(questType))
            {
                currentDialogContainer = container;
                break;
            }
        }

        return currentDialogContainer;
    }

    private void InitializeDialogEncounters(DialogContainer dialogContainer)
    {
        var dialogEncounterPair = dialogContainer.GetDialogEncounters();

        foreach (var pair in dialogEncounterPair)
        {
            var encounter = pair.Encounter;
            var dialog = pair.Dialog;

            if (encounter is IDialogable dEncounter)
            {
                dEncounter.InitializeDialogable(this);
                dEncounter.SetDialog(dialog);
            }
        }
    }

    public override void StartSystem() { }

    public override void Clear()
    {
        //_questSubSystem.OnQuestWillActivated -= InitializeDialogEncountersByQuestType;
        _questSubSystem = null;
    }
}

[System.Serializable]
public class DialogContainer
{
    [SerializeField] private Quest _quest = null;
    [SerializeField] private List<DialogEncounter> _dialogEncounter;

    public bool IsEqual(Type questType) => _quest.Type == questType;

    public List<DialogEncounter> GetDialogEncounters()
    {
        List<DialogEncounter> list = new List<DialogEncounter>();

        foreach (var encounter in _dialogEncounter)
            list.Add(encounter);

        return list;
    }

}

[System.Serializable]
public class DialogEncounter
{
    [SerializeField] private BaseEncounter _encounter = null;
    [SerializeField] private BaseDialog _dialog = null;

    public BaseEncounter Encounter => _encounter;
    public BaseDialog Dialog => _dialog;
}