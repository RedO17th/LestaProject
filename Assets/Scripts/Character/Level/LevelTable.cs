using UnityEngine;

[CreateAssetMenu(fileName = "LevelTable", menuName = "Data/Create New LevelTable")]
public class LevelTable : ScriptableObject
{
    public LevelTableString[] LevelTableStrings;
}

[System.Serializable]
public class LevelTableString
{
    public int Level;
    public int ProficiencyBonus;
    public int ExperienceBorder;
}
