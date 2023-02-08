using UnityEngine;

public class BaseScreen : MonoBehaviour
{
    public void ShowScreen() => gameObject.SetActive(true);

    public void HideScreen() => gameObject.SetActive(false);
}
