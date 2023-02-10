using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPlayerMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    private InventoryController _inventoryController = null;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        var playerSubSystem = ProjectSystem.GetSubSystem<PlayerSubSystem>();

        _inventoryController = playerSubSystem.GetPlayerController<InventoryController>();

        _inventoryController.OnMoneyChanged += Refresh;

        Refresh(_inventoryController.Money);
    }

    private void OnDisable()
    {
        //InventoryController.Instance.OnMoneyChanged -= Refresh;
    }

    private void Refresh(int value)
    {
        _moneyText.text = value.ToString();
    }
}
