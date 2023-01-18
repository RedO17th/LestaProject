using UnityEngine;

[CreateAssetMenu]
public class BaseDialog : ScriptableObject 
{
    [SerializeField] private int _dialogID = 0;

    public void ShowInfo()
    {
        Debug.Log($"Dialog ID is { _dialogID } ");
    }
}
