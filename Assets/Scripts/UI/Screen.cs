using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField] private BaseUIController[] _controllers = null;

    public virtual void ShowScreen() => gameObject.SetActive(true);

    public virtual void HideScreen() => gameObject.SetActive(false);
}
