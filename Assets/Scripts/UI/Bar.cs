using UnityEngine;
using UnityEngine.UI;

public class Bar : BaseBar
{
    [SerializeField] private float _fillerOffset = 0.0f;

    public override void Initialize()
    {
        _slider.maxValue += _fillerOffset;
    }

    public override void SetValue(float value)
    {
        _slider.value = value + _fillerOffset;
    }
}