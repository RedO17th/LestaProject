using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField] private BaseUIController[] _controllers = null;

    [SerializeField] private string _screenID = null;

    public string ScreenID => _screenID;

    public virtual void ShowScreen() => gameObject.SetActive(true);

    public virtual void HideScreen() => gameObject.SetActive(false);
}
