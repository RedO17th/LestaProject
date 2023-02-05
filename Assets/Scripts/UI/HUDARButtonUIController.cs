using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDARButtonUIController : BaseUIController
{
    public event Action OnAREnableCalled = null;
    public event Action OnARDisableCalled = null;

    [SerializeField] private Image _DisabledImage = null;
    [SerializeField] private Image _EnabledImage = null;

    private bool isARButtonActive = false;

    [SerializeField] private BaseButton _ARButton = null;

    public void Awake()
    {
        InitializeButton();
    }


    private void InitializeButton()
    {
        _ARButton?.Initialize(OnARButtonClicked);
        _DisabledImage.gameObject.SetActive(true);
        _EnabledImage.gameObject.SetActive(false);
    }


    private void OnARButtonClicked()
    {
        if (isARButtonActive)
        {
            isARButtonActive = false;
            OnARDisableCalled?.Invoke();
            _DisabledImage.gameObject.SetActive(true);
            _EnabledImage.gameObject.SetActive(false);

        }
        else
        {
            isARButtonActive = true;
            OnAREnableCalled?.Invoke();
            _DisabledImage.gameObject.SetActive(false);
            _EnabledImage.gameObject.SetActive(true);
        }
    }
    

}
