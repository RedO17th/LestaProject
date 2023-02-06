using UnityEngine;

public class TabPage : MonoBehaviour
{
    [SerializeField] private string _tabID = null;

    public string TabsID => _tabID;
}
