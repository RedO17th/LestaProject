using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterCreationWindow : BaseWindow
{
    [SerializeField] private BaseRadioGroup _prehistoryRadioGroup = null;
    [SerializeField] private BasePointsDistributor _characteristicsDistributor = null;
    [SerializeField] private Image _fullLengthCharacter = null;
    [SerializeField] private Sprite[] _fullLengthSprites = null;
    [SerializeField] private CommonButtonWrapper _backButton = null;
    [SerializeField] private CommonButtonWrapper _continueButton = null;

    private int _currentRadioValue = 0;

    public void OnEnable()
    {
        _prehistoryRadioGroup.OnRadioSwitched += HandleOnRadioSwitched;
        _backButton.OnButtonClicked += HandleOnButtonClicked;
        AddNavigationPair(_backButton, nameof(MainMenuWindow));
        //AddNavigationPair(_continueButton, nameof(LoadGameWindow));
    }


    private void HandleOnButtonClicked(IButtonWrapper clickedButton)
    {
        string calledScreenTypeName = string.Empty;
        if (_navigationButtonsScreenPair.TryGetValue(clickedButton, out calledScreenTypeName))
        {
            EventSystem.UIEvents.InvokeOnWindowCalled(calledScreenTypeName, this);
        }
    }


    private void HandleOnRadioSwitched(int radioValue)
    {
        if (radioValue != _currentRadioValue)
        {
            _currentRadioValue = radioValue;
            if (_fullLengthSprites.Length > radioValue)
            {
                _fullLengthCharacter.sprite = _fullLengthSprites[radioValue];
            }

            _characteristicsDistributor.Reset();
        }
        
    }


    public void OnDisable()
    {
        _prehistoryRadioGroup.OnRadioSwitched -= HandleOnRadioSwitched;
    }

}
