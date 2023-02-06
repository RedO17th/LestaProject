using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(ImageAlphaCutoff))]
[RequireComponent(typeof(Image))]
public abstract class BaseButton : Button, IButton
{
    public virtual void Subscribe(UnityAction<BaseButton> listener)
    {
        onClick.AddListener(() => listener(this));
    }
}
