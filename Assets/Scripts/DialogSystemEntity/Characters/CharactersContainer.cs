using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharactersDialogueInfo", menuName = "ScriptableObjects/Container/CharactersDialogueInfo", order = 1)]

public class CharactersContainer : BaseDataContainer
{
    [SerializeField] List<CharacterDialogueInfo> _characters;

    public CharacterDialogueInfo GetCharacterByTag(string tag)
    {
        var charInfo = _characters.Find(x => x.Tag.Equals(tag));
        return charInfo == null ? new CharacterDialogueInfo() : charInfo;
    }
}
