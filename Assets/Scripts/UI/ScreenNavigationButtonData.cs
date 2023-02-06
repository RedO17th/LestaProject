using UnityEngine;

public class ScreenNavigationButtonData : MonoBehaviour, IButtonData
{
    [SerializeField] private string _screenID = null;
    public string ScreenID => _screenID; 
}
