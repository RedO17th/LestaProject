using System;
using UnityEngine;
using static UISubSystem;

public class Screen : MonoBehaviour
{
    [SerializeField] private ScreenID _id = ScreenID.Default;

    public ScreenID ID => _id;

    public virtual void ShowScreen() => gameObject.SetActive(true);

    public virtual void HideScreen() => gameObject.SetActive(false);
}

[Serializable]
public enum ScreenID
{
    Default = -1,
    HUD = 0,
    Inventory = 1,
    Journal = 2,
    Skills = 3,
    PauseMenu = 4,
    Dialogue = 5,
    Settings = 6
}
