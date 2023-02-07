using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool _isPaused = false;
    public bool IsPaused => _isPaused;

    void Start()
    {
        _isPaused = false;
        EventSystem.OnPauseCalled += Pause;
        EventSystem.OnResumeCalled += Resume;
    }

    private void Pause()
    {
        Debug.Log("PauseManager : pause");
        _isPaused = true;
        Time.timeScale = 0;
    }

    private void Resume()
    {
        Debug.Log("PauseManager : resume");
        _isPaused = false;
        Time.timeScale = 1;
    }
}
