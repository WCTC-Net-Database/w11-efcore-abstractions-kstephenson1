using ConsoleRpg.DataTypes;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;
using ConsoleRpg.Models.Units.Characters;

namespace ConsoleRpg.Models.Items.EquippableItems.ArmorItems;

public abstract class ArmorItem : EquippableItem, IEquippableArmor
{
    public abstract ArmorType ArmorType { get; set; }
    public int Defense { get; set; }
    public int Resistance { get; set; }

    public ArmorItem(string name, ArmorType armorType, Rank requiredRank, int maxDurability, int defense, int resistance, int weight, int expModifier) : base(name, requiredRank, maxDurability, weight, expModifier)
    {
        ArmorType = armorType;
        Defense = defense;
        Resistance = resistance;
    }
}
