using System;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public interface IButtonWrapper
{
    event Action<IButtonWrapper> OnButtonClicked;
    void HandleOnButtonClicked();

    //Оставлен до лучших времён
    //void Initialize()
}


public abstract class BaseButtonWraper : MonoBehaviour, IButtonWrapper
{
    [SerializeField] protected Button _button = null;

    public event Action<IButtonWrapper> OnButtonClicked;

    //While override use base method necessarily!
    public virtual void Awake()
    {
        if (_button == null)
        {
            _button = transform.Find("Button").GetComponent<Button>();
        }
        _button.onClick.AddListener(HandleOnButtonClicked);
        if (_button.GetComponent<ImageAlphaCutoff>() == null)
        {
            var imageAlphaCutoff = _button.gameObject.AddComponent(typeof(ImageAlphaCutoff)) as ImageAlphaCutoff;
            imageAlphaCutoff.AlphaLevel = 0.1f;
        }
        Initialize();
    }

    public virtual void Initialize() { }

    //While override use base method necessarily!
    public virtual void HandleOnButtonClicked()
    {
        OnButtonClicked?.Invoke(this);
    }
}



