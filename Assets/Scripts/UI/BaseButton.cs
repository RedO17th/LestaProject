using UnityEngine.Events;
using UnityEngine.UI;

public class BaseButton : Button
{
    public void Initialize(UnityAction listener)
    {
        onClick.AddListener(listener);
    }
}
