using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "PrehistoryButtonSettings", menuName = "ScriptableObjects/UIResourses/PrehistoryButtonSettings")]
public class PrehistoryButtonCommonResorses : BaseUIResourse 
{
    [Header("Спрайты рамки")]
    public Sprite ActiveFrame;
    public Sprite InactiveFrame;
    [Space(15)]

    [Header("Спрайты задника")]
    public Sprite ActiveBackground;
    public Sprite InactiveBackground;
}
