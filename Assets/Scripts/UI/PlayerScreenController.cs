using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScreenController : ScreenController
{
    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
