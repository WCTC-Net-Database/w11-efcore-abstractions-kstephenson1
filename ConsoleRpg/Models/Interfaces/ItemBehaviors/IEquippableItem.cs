using ConsoleRpg.DataTypes;

namespace ConsoleRpg.Models.Interfaces.ItemBehaviors;

public interface IEquippableItem : IItem
{
    public Rank RequiredRank { get; set; }
    public int MaxDurability { get; set; }
    public int Durability { get; set; }
    public int Weight { get; set; }
    public int ExpModifier { get; set; }
    public void Equip();
    public void TakeDurabilityDamage(int durabilityDamage);
    public void BreakItem();
}
