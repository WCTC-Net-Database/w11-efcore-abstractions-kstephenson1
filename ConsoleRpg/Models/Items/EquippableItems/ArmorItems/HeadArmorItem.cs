using ConsoleRpg.DataTypes;

namespace ConsoleRpg.Models.Items.EquippableItems.ArmorItems;

public class HeadArmorItem : ArmorItem
{
    public override string ItemType { get; set; } = "HeadArmorItem";
    public override ArmorType ArmorType { get; set; } = ArmorType.Head;
    public HeadArmorItem(string name, ArmorType armorType, Rank requiredRank, int maxDurability, int defense, int resistance, int weight, int expModifier) : base(name, armorType, requiredRank, maxDurability, defense, resistance, weight, expModifier)
    {

    }
}
