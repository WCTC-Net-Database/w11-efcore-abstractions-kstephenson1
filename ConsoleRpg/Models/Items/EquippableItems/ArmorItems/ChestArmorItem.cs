using ConsoleRpg.DataTypes;

namespace ConsoleRpg.Models.Items.EquippableItems.ArmorItems;

public class ChestArmorItem : ArmorItem
{
    public override string ItemType { get; set; } = "ChestArmorItem";
    public override ArmorType ArmorType { get; set; } = ArmorType.Chest;
    public ChestArmorItem(string name, ArmorType armorType, Rank requiredRank, int maxDurability, int defense, int resistance, int weight, int expModifier) : base(name, armorType, requiredRank, maxDurability, defense, resistance, weight, expModifier)
    {

    }
}
