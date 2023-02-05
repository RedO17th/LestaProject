using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMenuNavigationUIController : BaseUIController
{
    [SerializeField] protected BaseButton _leftArrowButton = null;
    [SerializeField] protected BaseButton _rightArrowButton = null;
    [SerializeField] protected BaseButton _exitButton = null;

    public virtual void Awake()
    {
        PrepareSubordinates();
    }

    protected void PrepareSubordinates()
    {
        _leftArrowButton?.Initialize(LeftArrowButtonClickListener);
        _rightArrowButton?.Initialize(RightArrowButtonClickListener);
        _exitButton?.Initialize(ExitButtonClickListener);
    }

    protected abstract void LeftArrowButtonClickListener();

    protected abstract void RightArrowButtonClickListener();

    protected void ExitButtonClickListener()
    {
        EventSystem.InvokeOnPlayerMenuExit();
    }
}
