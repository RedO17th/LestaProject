using UnityEngine;
using UnityEngine.UI;

public class Bar : BaseBar
{
    [SerializeField]
    private Slider slider;

    private const int maxValue = 1;
    private const int minValue = 0;

    public void Awake()
    {
        slider.value = maxValue;
    }

    public override void ChangeValue(float newValue) => slider.value = newValue;
}