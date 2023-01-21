using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    private const int maxValue = 1;
    private const int minValue = 0;

    public void Awake()
    {
        slider.value = maxValue;
    }

    public void ChangeValue(float changing) => slider.value = slider.value + changing;
}