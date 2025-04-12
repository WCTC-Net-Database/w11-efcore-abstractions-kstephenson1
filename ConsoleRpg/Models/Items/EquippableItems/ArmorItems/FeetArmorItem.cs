﻿using ConsoleRpg.DataTypes;

namespace ConsoleRpg.Models.Items.EquippableItems.ArmorItems;

public class FeetArmorItem : ArmorItem
{
    public override string ItemType { get; set; } = "FeetArmorItem";
    public override ArmorType ArmorType { get; set; } = ArmorType.Feet;
    public FeetArmorItem(string name, ArmorType armorType, Rank requiredRank, int maxDurability, int defense, int resistance, int weight, int expModifier) : base(name, armorType, requiredRank, maxDurability, defense, resistance, weight, expModifier)
    {

    }
}
