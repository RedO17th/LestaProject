using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPlayerMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    private void Start()
    {
        //PlayerSubSystem playerSubSystem = ProjectSystem.Instance.GetSubSystemByType(typeof(PlayerSubSystem)) as PlayerSubSystem;
        //InventoryController inventoryController = ((GamePlayer)playerSubSystem.Player).GetControllerBy(PlayerControllerType.Inventory) as InventoryController;
        //inventoryController.OnMoneyChanged += Refresh;
        InventoryController.Instance.OnMoneyChanged += Refresh;
        //OnMoneyChanged += Refresh();    
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
