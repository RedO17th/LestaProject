using System;
using UnityEngine;

[Serializable]
public class PauseMenuButtonData : MonoBehaviour, IButtonData
{
    public PauseMenuButtonsEnum ButtonType => _buttonType;
    [SerializeField] private PauseMenuButtonsEnum _buttonType = PauseMenuButtonsEnum.Default;

    public Sprite ActiveSprite => _activeSprite;
    [SerializeField] private Sprite _activeSprite = null;

    public Sprite InactiveSprite => _inactiveSprite;
    [SerializeField] private Sprite _inactiveSprite = null;
}
