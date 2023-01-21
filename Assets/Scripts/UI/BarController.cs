using UnityEngine;

public class BarController : MonoBehaviour
{
    [SerializeField]
    private BaseBar _HPbar = null;

    [SerializeField]
    private BaseBar _EnergyBar = null;

    //TODO: Get max value
    private int _maxIndicatorValue = 100;


    public void Initialize()
    {

    }

    public void Awake()
    {
        Initialize();
        EventManager.OnHealthChanged += HandleOnHealthChanged;
    }

    private float CalculatePercentageChanging(int changing)
    {
        return (float)changing / _maxIndicatorValue;
    }

    private void HandleOnHealthChanged(int changing)
    {
        float percentageChanging = CalculatePercentageChanging(changing);
        if (_HPbar is IBaseBar bar) 
            bar?.ChangeValue(percentageChanging);
    }

    public void OnDestroy()
    {
        EventManager.OnHealthChanged-= HandleOnHealthChanged;
    }
}
