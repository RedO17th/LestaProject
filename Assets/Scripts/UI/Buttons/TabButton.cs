using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TabButtonData))]
public class TabButton : BaseButton, IButtonWithData, IToggledButton
{
    public IButtonData Data => _data;
    [SerializeField] private TabButtonData _data = null;

    public void Initialize()
    {   
        _data = GetComponent<TabButtonData>();
    }

    public void SetActive()
    {
        this.gameObject.GetComponent<Image>().sprite = _data.ActiveSprite;
    }

    public void SetInactive()
    {
        this.gameObject.GetComponent<Image>().sprite = _data.InactiveSprite;
    }
}

