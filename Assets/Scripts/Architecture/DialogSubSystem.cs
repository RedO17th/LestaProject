using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[Note] ≈сли вынести инициализацию "диалоговых энкаунтеров" в данную подсистему,
//как функционал, то уже она будет решать, есть ли эти самые
//сущности внутри определенного quest'a и выполн€ть определенную логику

public class DialogSubSystem : BaseSubSystem
{
    [SerializeField] private DialogueController _dialogueController;

    private QuestSubSystem _questSubSystem = null;
    private DiceTwentySubSystem _diceTwentySubSystem = null;

    private CharactersContainer _characters = null;
    private DialogueDataContainer _dialogueDataContainer = null;

    public override void Initialize(ProjectSystem system) => base.Initialize(system);

    public TextAsset GetDialogueByName(string name)
    {
        return _dialogueDataContainer.GetDialogueByName(name);
    }

    public override void Prepare()
    {
        _diceTwentySubSystem = _projectSystem.GetSubSystemByType(typeof(DiceTwentySubSystem)) as DiceTwentySubSystem;

        var settingsSystem = _projectSystem.GetSubSystemByType(typeof(SettingsSubSystem)) as SettingsSubSystem;
        
        _characters = settingsSystem?.GetDataContainerByType(typeof(CharactersContainer)) as CharactersContainer;
        _dialogueDataContainer = settingsSystem?.GetDataContainerByType(typeof(DialogueDataContainer)) as DialogueDataContainer;


        _dialogueController.Initialize(this);
    }

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
        _questSubSystem = null;
    }
}
