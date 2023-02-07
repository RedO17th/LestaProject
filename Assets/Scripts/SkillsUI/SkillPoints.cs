using System;
public class SkillPoints
{
    public event Action<int> OnPointsChanged;
    public int Points { get; private set; }

    public void AddSkillPoint(int pointsAmount = 1)
    {
        Points += pointsAmount;
        OnPointsChanged?.Invoke(Points);
    }

    public bool TryToRemoveSkillPoint(int pointsAmount = 1)
    {
        if (Points - pointsAmount < 0)
            return false;

        RemoveSkillPoint(pointsAmount);
        return true;
    }

    private void RemoveSkillPoint(int pointsAmount = 1)
    {
        Points -= pointsAmount;
        OnPointsChanged?.Invoke(Points);
    }
}