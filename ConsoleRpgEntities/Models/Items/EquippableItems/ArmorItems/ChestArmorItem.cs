using ConsoleRpgEntities.DataTypes;

namespace ConsoleRpgEntities.Models.Items.EquippableItems.ArmorItems;

public class ChestArmorItem : ArmorItem
{
    public override string ItemType { get; set; } = "ChestArmorItem";
    public override ArmorType ArmorType { get; set; } = ArmorType.Chest;
    public ChestArmorItem() : base() { }
    public ChestArmorItem(string name, ArmorType armorType, Rank requiredRank, int maxDurability, int defense, int resistance, int weight, int expModifier) : base(name, armorType, requiredRank, maxDurability, defense, resistance, weight, expModifier)
    {

    }
}
