using ConsoleRpgEntities.DataTypes;

namespace ConsoleRpgEntities.Models.Items.EquippableItems.ArmorItems;

public class FeetArmorItem : ArmorItem
{
    // FeetArmorItem is a class that represents an item that can be equipped to the feet of a unit.
    public override string ItemType { get; set; } = "FeetArmorItem";
    public override ArmorType ArmorType { get; set; } = ArmorType.Feet;
    public FeetArmorItem() : base() { }
    public FeetArmorItem(string name, ArmorType armorType, Rank requiredRank, int maxDurability, int defense, int resistance, int weight, int expModifier) : base(name, armorType, requiredRank, maxDurability, defense, resistance, weight, expModifier)
    {

    }
}
