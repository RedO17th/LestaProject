public interface IWeapon : IEquipment
{
    int AttackBonus { get; }
    Dice DamageDice { get; }
    int DamageBonus { get; }
    int DamageDiceAmount { get; }

    
}
