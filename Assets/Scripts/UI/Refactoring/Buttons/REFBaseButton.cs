using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class REFBaseButton : Button
{
    public virtual void Initialize(UnityAction<REFBaseButton> listener)
    {
        onClick.AddListener(() => listener(this));
    }
}