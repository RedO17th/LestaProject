using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[Note] ≈сли вынести инициализацию "диалоговых энкаунтеров" в данную подсистему,
//как функционал, то уже она будет решать, есть ли эти самые
//сущности внутри определенного quest'a и выполн€ть определенную логику

public class DialogSubSystem : BaseSubSystem
{
    [SerializeField] private DialogueSceneController _dialogueController;

    private DiceTwentySubSystem _diceTwentySubSystem = null;

    private CharactersContainer _charactersData = null;
    private DialogueDataContainer _dialogueData = null;

    public override void Initialize(ProjectSystem system) => base.Initialize(system);

    public BaseDialogue GetDialogueByName(string name)
    {
        return _dialogueData.GetDialogueByName(name);
    }

    public override void Prepare()
    {
        _dialogueController.Initialize(this);

        _diceTwentySubSystem = _projectSystem.GetSubSystemByType(typeof(DiceTwentySubSystem)) as DiceTwentySubSystem;

        var settingsSystem = _projectSystem.GetSubSystemByType(typeof(SettingsSubSystem)) as SettingsSubSystem;
        
        _charactersData = settingsSystem?.GetDataContainerByType(typeof(CharactersContainer)) as CharactersContainer;
        _dialogueData = settingsSystem?.GetDataContainerByType(typeof(DialogueDataContainer)) as DialogueDataContainer;
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

    public override void Clear() { }
}
