using UnityEngine;
using UnityEngine.UI;

public class Bar : BaseBar
{
    [SerializeField] private Slider _slider;

    public override void SetMaxValue(int value)
    {
        _slider.maxValue = value;
        _slider.value = value;
    }
    public override void SetValue(int value)
    {
        _slider.value = value;
    }
}