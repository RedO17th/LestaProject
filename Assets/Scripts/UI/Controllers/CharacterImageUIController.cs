using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterImageUIController : BaseUIController
{
    [SerializeField] private Sprite[] _charactersSprites = null;
    private Dictionary<PrehistoryEnum, Sprite> _characterDict = null;
    private Image _selfImage = null;

    public void Start()
    {
        _selfImage = GetComponent<Image>();

        InitializeCharacterDictionary();

        if (_charactersSprites.Length > 0)
        {
            SetCharacterSprite(_charactersSprites[0]);
        }

        PrehistoryButtonsUIController.OnPrehistoryButtonClicked += SetCharacterSprite;
    }

    private void InitializeCharacterDictionary()
    {
        _characterDict = new Dictionary<PrehistoryEnum, Sprite>();
        for (
            int i = 0;
            i < _charactersSprites.Length && Enum.IsDefined(typeof(PrehistoryEnum), i);
            i++
            )
        {
            _characterDict.Add((PrehistoryEnum)i, _charactersSprites[i]);
        }
    }

    private void SetCharacterSprite(PrehistoryEnum prehistory)
    {
        Sprite sprite = null;
        if (_characterDict.TryGetValue(prehistory, out sprite))
        {
            SetCharacterSprite(sprite);
        }
    }

    private void SetCharacterSprite(Sprite sprite)
    {
        _selfImage.sprite = sprite;
    }
}

