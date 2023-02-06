using UnityEngine;

public class TabButtonData : MonoBehaviour, IButtonData
{
    [SerializeField] private string _tabID = null;

    public string TabID => _tabID;

    public Sprite ActiveSprite => _activeSprite;
    [SerializeField] private Sprite _activeSprite = null;
    
    public Sprite InactiveSprite => _inactiveSprite;
    [SerializeField] private Sprite _inactiveSprite = null;
}

