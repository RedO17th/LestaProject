using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class OLDBaseButton : Button, IButton
{
    public virtual void Subscribe(UnityAction<OLDBaseButton> listener)
    {
        onClick.AddListener(() => listener(this));
    }
}
