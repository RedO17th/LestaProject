using System;
using UnityEngine;


public class BaseUIController : MonoBehaviour
{
    //¬ идеале тип массива должен быть IWindow,
    //но Unity не позвол€ет сериализовать поле типа интерфейс
    [SerializeField] private BaseWindow[] _windows = null;


    public virtual void OnEnable()
    {
        EventSystem.UIEvents.OnScreenCalled += HandleOnScreenCalled;
    }


    protected void HandleOnScreenCalled(string windowTypeName, IWindow caller)
    {
        bool isVerifiedCaller = false;
        foreach (var window in _windows)
        {
            if (window == (BaseWindow) caller)
            {
                isVerifiedCaller = true;
                break;
            }
        }

        if (isVerifiedCaller)
        {
            ShowWindow(windowTypeName);
        }
    }


    protected void ShowWindow(string windowTypeName)
    {
        //«ащита от отсутсви€ окна, получаемого через серализованный массив
        //ѕеред релизом стоит удалить
        bool isWindowDisplayed = false;

        foreach (var window in _windows)
        {
            if (window.GetType().Name == windowTypeName)
            {
                window.Show();
                isWindowDisplayed = true;
            }
            else
            {
                window.Hide();
            }
        }
        if (!isWindowDisplayed)
        {
            throw new Exception("Can't find window of " + windowTypeName + " in " + nameof(this.GetType));
        }
    }
}



