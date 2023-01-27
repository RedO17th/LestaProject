using System;
using System.Diagnostics;

public abstract class BaseVitalSign
{
    public event Action<int> OnValueChanged;
    public int MinValue => _minValue;
    public int MaxValue => _maxValue;

    private const int _minValue = 0;
    private int _maxValue = 0;
    private int _currentValue = 0;

    public int CurrentValue
    {
        get
        {
            return _currentValue;
        }

        set
        {
            if (value > _maxValue)
                _currentValue = _maxValue;
            else if (value < _minValue)
                _currentValue = _minValue;
            else
                _currentValue = value;
            OnValueChanged?.Invoke(_currentValue);
        }
    }

    public BaseVitalSign(int maxValue)
    {
        _maxValue = maxValue;
        _currentValue = maxValue;
    }
}
