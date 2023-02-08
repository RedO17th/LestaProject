using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum QuickAccessButtonID
{
    NonValideButton = -1,
    FirstButton = 0,
    SecondButton = 1,
    ThirdButton = 2,
    FourthButton = 3,
    FifthButton = 4,
    SixthButton = 5,
    SeventhButton = 6,
}


public class QuickAccessPanelUIController : BaseUIController
{
    private BaseButton[] _consumablesButtons = null;
    private BaseButton[] _skillsButtons = null;

    public event Action<QuickAccessButtonID> OnConsumableCalled = null;
    public event Action<QuickAccessButtonID> OnSkillCalled = null;
    
    public void Awake()
    {
        //InitializeConsumablesButtons();

        //InitializeSkillsButtons();
    }

    public void OnEnable()
    {
        
    }


    public void InitializeConsumablesButtons()
    {
        for (int i = 0; i < _consumablesButtons.Length; i++)
        {
            //_consumablesButtons[i].Initialize(QAConsumableClickListener, (QuickAccessButtonID)i);
        }
    }


    public void InitializeSkillsButtons()
    {
        for (int i = 0; i < _skillsButtons.Length; i++)
        {
            //_skillsButtons[i].Initialize(QASkillClickListener, (QuickAccessButtonID)i);
        }
    }


    private void QASkillClickListener(QuickAccessButtonID buttonID)
    {
        OnSkillCalled?.Invoke(buttonID);
    }
    
    private void QAConsumableClickListener(QuickAccessButtonID buttonID)
    {
        OnConsumableCalled?.Invoke(buttonID);
    }
}
