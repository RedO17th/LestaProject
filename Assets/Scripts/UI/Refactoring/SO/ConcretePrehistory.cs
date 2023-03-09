using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "ConcretePrehistory", menuName = "ScriptableObjects/UIResourses/ConcretePrehistory")]
public class ConcretePrehistory : BaseUIResourse 
{
    [Header("Спрайты портрета")]
    public Sprite ActivePortrait;
    public Sprite InactivePortrait;
    [Header("Спрайт в полный рост")]
    public Sprite FullLength;
}
