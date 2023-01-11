using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePointer : MonoBehaviour
{
    [SerializeField] protected GameObject _view;

    public virtual void Enable()
    {
        _view.SetActive(true);
    }

    public virtual void Disable()
    {
        _view.SetActive(false);
    }
}
