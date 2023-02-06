using UnityEngine;
using UnityEngine.UI;

public abstract class BaseBar : MonoBehaviour
{
    [SerializeField] protected Slider _slider;

    public abstract void SetValue(float value);

    public abstract void Initialize();
}

