using UnityEngine;

[System.Serializable]
public class GameDataContainer : MonoBehaviour
{
    public static GameDataContainer Instance;

    public PlayerInventoryData PlayerInventoryData { get; private set; }
    public UISkillStatesData UISkillStatesData { get; private set; }
    public PlayerJournalData PlayerJournalData { get; private set; }

    private void Awake() { Instance = this; }

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
