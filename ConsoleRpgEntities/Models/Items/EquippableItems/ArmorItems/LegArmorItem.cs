using ConsoleRpgEntities.DataTypes;

namespace ConsoleRpgEntities.Models.Items.EquippableItems.ArmorItems;

public class LegArmorItem : ArmorItem
{
    public override string ItemType { get; set; } = "LegArmorItem";
    public override ArmorType ArmorType { get; set; } = ArmorType.Legs;
    public LegArmorItem() : base() { }
    public LegArmorItem(string name, ArmorType armorType, Rank requiredRank, int maxDurability, int defense, int resistance, int weight, int expModifier) : base(name, armorType, requiredRank, maxDurability, defense, resistance, weight, expModifier)
    {

    }
}
