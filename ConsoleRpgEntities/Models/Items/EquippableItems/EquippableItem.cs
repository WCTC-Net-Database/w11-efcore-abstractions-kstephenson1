﻿using ConsoleRpgEntities.DataTypes;
using ConsoleRpgEntities.Models.Interfaces.ItemBehaviors;

namespace ConsoleRpgEntities.Models.Items.EquippableItems;

public abstract class EquippableItem : Item, IEquippableItem
{

    // EquippableItem is a class that holds equippable item information.

    public Rank RequiredRank { get; set; }
    public int MaxDurability { get; set; }
    public int Durability { get; set; }
    public int Weight { get; set; }
    public int ExpModifier { get; set; }

    protected EquippableItem() { }

    public EquippableItem(string name, Rank requiredRank, int maxDurability, int weight, int expModifier) : base(name)
    {
        MaxDurability = maxDurability;
        Name = name;
        RequiredRank = requiredRank;
        Weight = weight;
        Durability = maxDurability;
        ExpModifier = expModifier;
    }

    public override string ToString()
    {
        return $"[[{Durability}/{MaxDurability}]] {Name}";
    }

    public void TakeDurabilityDamage(int durabilityDamage)
    {
        throw new NotImplementedException();
    }

    public void BreakItem()
    {
        throw new NotImplementedException();
    }
}
