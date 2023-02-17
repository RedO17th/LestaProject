using UnityEngine;
using UnityEngine.UI;

public class PrehistoryButtonData : MonoBehaviour, IButtonData
{
    [Header("ID предыстории")]
    [SerializeField] private PrehistoryEnum _prehistory = PrehistoryEnum.Default;
    [Space]

    [Header("Image компоненты")]
    [SerializeField] private Image _frameImage = null;
    [SerializeField] private Image _portraitImage = null;
    [SerializeField] private Image _backgroundImage = null;
    [Space]

    [Header("Спрайты рамки")]
    [SerializeField] private Sprite _activeFrameSprite = null;
    [SerializeField] private Sprite _inactiveFrameSprite = null;
    [Space]

    [Header("Спрайты портрета")]
    [SerializeField] private Sprite _activePortraitSprite = null;
    [SerializeField] private Sprite _inactivePortraitSprite = null;
    [Space]

    [Header("Спрайты задника")]
    [SerializeField] private Sprite _activeBackgroundSprite = null;
    [SerializeField] private Sprite _inactiveBackgroundSprite = null;

    public Sprite ActiveFrameSprite => _activeFrameSprite;
    public Sprite InactiveFrameSprite => _inactiveFrameSprite;
    public Sprite ActivePortraitSprite => _activePortraitSprite;
    public Sprite InactivePortraitSprite => _inactivePortraitSprite;
    public Sprite ActiveBackgroundSprite => _activeBackgroundSprite;
    public Sprite InactiveBackgroundSprite => _inactiveBackgroundSprite;
    public Image FrameImage => _frameImage;
    public Image PortraitImage => _portraitImage;
    public Image BackgroundImage => _backgroundImage;
    public PrehistoryEnum Prehistory => _prehistory;
}

public enum PrehistoryEnum
{
    Default = -1,
    Tisha = 0,
    History2 = 1,
    History3 = 2,
    History4 = 3,
    History5 = 4,
    History6 = 5,
}
