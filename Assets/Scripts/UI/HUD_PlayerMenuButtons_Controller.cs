using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_PlayerMenuButtons_Controller : BaseUIController
{
    public event Action OnClipboardMenuCalled = null;
    public event Action OnSkillsMenuCalled = null;

    [SerializeField] private HUD_Button _clipboardButton = null;
    [SerializeField] private HUD_Button _skillsButton = null;

    public override void Initialize(BaseWindow window)
    {
        base.Initialize(window);

        InitializeButtons();
    }

    private void InitializeButtons()
    {
        _clipboardButton?.Initialize(ClippboardMenuButtonClickListener);
        _skillsButton?.Initialize(SkillsMenuButtonClickListener);
    }

    private void ClippboardMenuButtonClickListener()
    {
        OnClipboardMenuCalled?.Invoke();
    }
    
    private void SkillsMenuButtonClickListener()
    {
        OnSkillsMenuCalled?.Invoke();
    }


}
