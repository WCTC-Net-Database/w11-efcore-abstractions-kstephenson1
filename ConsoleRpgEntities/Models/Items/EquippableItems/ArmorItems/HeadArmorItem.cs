using ConsoleRpgEntities.DataTypes;

namespace ConsoleRpgEntities.Models.Items.EquippableItems.ArmorItems;

public class HeadArmorItem : ArmorItem
{
    // HeadArmorItem is a class that represents a head armor item.
    public override string ItemType { get; set; } = "HeadArmorItem";
    public override ArmorType ArmorType { get; set; } = ArmorType.Head;
    public HeadArmorItem() : base() { }
    public HeadArmorItem(string name, ArmorType armorType, Rank requiredRank, int maxDurability, int defense, int resistance, int weight, int expModifier) : base(name, armorType, requiredRank, maxDurability, defense, resistance, weight, expModifier)
    {

    }
}
