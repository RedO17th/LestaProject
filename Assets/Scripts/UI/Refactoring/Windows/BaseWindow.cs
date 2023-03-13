using System;
using System.Collections.Generic;
using UnityEngine;


public interface IWindow
{
    public void Show();
    public void Hide();
}

public interface IHaveButtons 
{
    void SubscribeToButtonsEvents();
    void UnsubscribeToButtonsEvents();
}



//TODO: After refactoring rename all window-names to screen
public abstract class BaseWindow : MonoBehaviour, IWindow
{
    protected Dictionary<IButtonWrapper, Action> _buttonsAction = null;

    protected Dictionary<IButtonWrapper, string> _navigationButtonsScreenPair = null;

    protected void AddNavigationPair(IButtonWrapper button, string windowTypeName)
    {
        if (_navigationButtonsScreenPair == null)
        {
            _navigationButtonsScreenPair = new Dictionary<IButtonWrapper, string>();
        }

        _navigationButtonsScreenPair.TryAdd(button, windowTypeName);
    }

    public void Show() => gameObject.SetActive(true);
    
    public void Hide() => gameObject.SetActive(false);
}

