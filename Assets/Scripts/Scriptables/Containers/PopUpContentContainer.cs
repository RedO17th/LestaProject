
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PopUpContentContainer", menuName = "ScriptableObjects/Container/PopUpContentContainer")]
public class PopUpContentContainer : BaseDataContainer
{
    [TextArea]
    [SerializeField] public string Header = string.Empty;

    [TextArea]
    [SerializeField] public string Content = string.Empty;

    [TextArea]
    [SerializeField] public string ButtonText = string.Empty;

    public bool isOverlay = false;
}

