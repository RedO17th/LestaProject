using UnityEngine;

public class ScreenNavigationButtonData : MonoBehaviour, IButtonData
{
    [SerializeField] private IngameScreenID _id = IngameScreenID.Default;
    public IngameScreenID ID => _id; 
}
