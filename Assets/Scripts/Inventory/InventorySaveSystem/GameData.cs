using UnityEngine;
[System.Serializable]
public class GameData : MonoBehaviour
{
    public static GameData Instance;
    public PlayerInventoryData PlayerInventoryData { get; private set; }
    public UISkillStatesData UISkillStatesData { get; private set; }
    public PlayerJournalData PlayerJournalData { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private GameData()
    {
  
    }

    public void AddPlayerInventoryData(PlayerInventoryData playerInventoryData)
    {
        PlayerInventoryData = playerInventoryData;
    }

    public void AddUISkillStatesData(UISkillStatesData uiSkillStatesData)
    {
        UISkillStatesData = uiSkillStatesData;
    }

    public void AddPlayerJournalData(PlayerJournalData playerJournalData)
    {
        PlayerJournalData = playerJournalData;
    }
}
