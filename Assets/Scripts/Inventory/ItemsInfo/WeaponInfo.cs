using UnityEngine;

[CreateAssetMenu(fileName = "WeaponInfo", menuName = "Gameplay/Items/Create New WeaponInfo")]
public class WeaponInfo : EquipmentInfo
{
    [SerializeField] private int _attackBonus;
    [SerializeField] private Dice _damageDice;
    [SerializeField] private int _damageDiceAmount;
    [SerializeField] private int _damageBonus;
    [SerializeField] private InventoryItemInfo _bullets;

    public int AttackBonus => _attackBonus;
    public Dice DamageDice => _damageDice;
    public int DamageDiceAmount => _damageDiceAmount;
    public int DamageBonus => _damageBonus;

    public InventoryItemInfo Bullets => _bullets;
}
