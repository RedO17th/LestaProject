using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ValueView : MonoBehaviour
{
    private TextMeshProUGUI _textComponent = null;

    public void Start()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
    }

    public void SetValue<T>(T value)
    {
        _textComponent.text = value.ToString();
    }
}
