[System.Serializable]
public class GameData
{
    public PlayerInventoryData PlayerInventoryData;

    public GameData(PlayerInventoryData playerInventoryData)
    {
        PlayerInventoryData = playerInventoryData;
    }
}
