using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    #region Events

    public static Action<int> OnHealthChanged;

    #endregion

    #region Event senders

    public static void SendHealthChanged(int changing) => OnHealthChanged?.Invoke(changing);

    #endregion
}
