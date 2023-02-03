using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Заглушка
public class Level
{
    public event Action<int> OnLevelChanged;
    public event Action<int> OnPointsChanged;

    public int CurrentLevel => _currentLevel;

    public float NormalizedPoints => (float)_currentPoints / _maxPoints;

    private int _currentLevel;

    private const int _startPoints = 0;

    private int _maxPoints;

    private int _currentPoints;

    public int CurrentPoints
    {
        get
        {
            return _currentPoints;
        }

        set
        {
            if (value > _maxPoints)
            {
                _currentPoints = value % _maxPoints;
                _currentLevel++;
                OnLevelChanged?.Invoke(_currentLevel);
            }
            else if (value < _startPoints)
                _currentPoints = _startPoints;
            else
                _currentPoints = value;
            OnPointsChanged?.Invoke(_currentPoints);
        }
    }

    public Level()
    {
        _maxPoints = 100;
        _currentPoints = _startPoints;
        _currentLevel = 1;
    }
}
