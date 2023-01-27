using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUIController : MonoBehaviour
{
    /* При обращении к особым окнам необходимо кастить поле окна-владельца
     * к своему типу. Если будет мешать - переделать, убрав поле ControlerHolder
     * и сделать метод Initialize абстрактным */

    protected BaseWindow _сontrollerHolder = null;

    public virtual void Initialize(BaseWindow window)
    {
        _сontrollerHolder = window;
    }
}
