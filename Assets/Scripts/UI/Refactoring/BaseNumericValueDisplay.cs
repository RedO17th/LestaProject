using TMPro;
using UnityEngine;

public interface IValueDisplay
{
    void ChangeDisplayedValue(int value);
}


public class BaseNumericValueDisplay : MonoBehaviour, IValueDisplay
{
    protected TextMeshProUGUI _valueText = null;

    public void OnEnable()
    {
        _valueText = transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void ChangeDisplayedValue(int value)
    {
        _valueText.text = value.ToString();
    }
}