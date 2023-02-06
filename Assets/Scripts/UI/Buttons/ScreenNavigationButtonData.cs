using UnityEngine;

public class ScreenNavigationButtonData : MonoBehaviour, IButtonData
{
    [SerializeField] private ScreenID _id = ScreenID.Default;
    public ScreenID ID => _id; 
}
