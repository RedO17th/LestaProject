using System;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public interface IButtonWrapper
{
    event Action<IButtonWrapper> OnButtonClicked;
    void HandleOnButtonClicked();
}


public abstract class BaseButtonWraper : MonoBehaviour, IButtonWrapper
{
    [SerializeField] protected Button _button = null;

    public event Action<IButtonWrapper> OnButtonClicked;


    public virtual void Awake()
    {
        Initialize();
    }

    public virtual void Initialize() 
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
    }


    public virtual void HandleOnButtonClicked()
    {
        OnButtonClicked?.Invoke(this);
    }
}



