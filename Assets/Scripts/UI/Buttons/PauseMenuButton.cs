using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PauseMenuButtonData))]
public class PauseMenuButton : BaseButton, IToggledButton, IButtonWithData
{
    public IButtonData Data => _data;
    [SerializeField] private PauseMenuButtonData _data = null;

    public void Initialize()
    {
        _data = GetComponent<PauseMenuButtonData>();
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

[Serializable]
public enum PauseMenuButtonsEnum
{
    Default = -1,
    Resume = 0,
    Save = 1,
    Load = 2,
    Settings = 3,
    Exit = 4
}
