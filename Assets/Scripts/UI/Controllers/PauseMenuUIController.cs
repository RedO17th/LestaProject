using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUIController : BaseUIController
{
    [SerializeField] private PauseMenuButton[] _pauseButton = null;

    public void Start()
    {
        foreach (PauseMenuButton button in _pauseButton)
        {
            button.Initialize();
            button.Subscribe(PauseButtonClickListener);
        }
    }

    public void PauseButtonClickListener(BaseButton sender)
    {
        PauseMenuButton button = sender as PauseMenuButton;
        PauseMenuButtonData data = button.Data as PauseMenuButtonData;
        switch (data.ButtonType)
        {
            case PauseMenuButtonsEnum.Resume:
                EventSystem.UIEvents.InvokeOnPlayerMenuExit();
                break;
                
            case PauseMenuButtonsEnum.Save:
                EventSystem.UIEvents.InvokeOnSaveCalled();
                Debug.Log("Save called");
                break;
                
            case PauseMenuButtonsEnum.Load:
                EventSystem.UIEvents.InvokeOnLoadCalled();
                Debug.Log("Load called");
                break;
                
            case PauseMenuButtonsEnum.Settings:
                EventSystem.UIEvents.InvokeOnScreenCalled(ScreenID.Settings);
                break;
                
            case PauseMenuButtonsEnum.Exit:
                Debug.Log("Exit called");
                break;
                
            default:
                break;
        }

    }
}
