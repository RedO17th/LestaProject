
[System.Serializable]
public class Weapon : Equipment, IWeapon
{
    public int AttackBonus { get; }
    public int DamageBonus { get; }
    public Dice DamageDice { get; }
    public int DamageDiceAmount { get; }

    public Weapon(WeaponInfo itemInfo) : base(itemInfo)
    {
        _itemInfo = itemInfo;
        AttackBonus = itemInfo.AttackBonus;
        DamageBonus = itemInfo.DamageBonus;
        DamageDice = itemInfo.DamageDice;
        DamageDiceAmount = itemInfo.DamageDiceAmount;
    }

    public override IInventoryItem Clone()
    {
        var clonnedItem = new Weapon((WeaponInfo)ItemInfo);
        clonnedItem.State.amount = State.amount;
        return clonnedItem;
    }

    public override void Equip()
    {
        State.isEquipped = true;
    }
    public override void UnEquip()
    {
        State.isEquipped = false;
    }
}
