using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletOfPoints
{

    public int GetPoints() => _points;

    private int _points = 0;

    public WalletOfPoints(int points)
    {
        _points = points;
    }

    public void Add(int points)
    {
        _points += points;
    }

    public void Remove(int points) 
    {
        var temporaryValue = _points - points;

        _points = temporaryValue <= 0 ? 0 : temporaryValue;
    }

    public void RemoveAll()
    {
        _points = 0;
    }
}
