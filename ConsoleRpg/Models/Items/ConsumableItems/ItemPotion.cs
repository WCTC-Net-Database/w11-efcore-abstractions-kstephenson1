﻿using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;

namespace ConsoleRpg.Models.Items.ConsumableItems;

public class ItemPotion : ConsumableItem, IConsumableItem
{
    public override string ItemType { get; set; } = "ItemPotion";

    public ItemPotion()
    {
        Name = "Potion";
        Description = "Use to restore 10 hp.";
        MaxUses = 3;
        UsesLeft = MaxUses;
    }

    public ItemPotion(string name, string desc) : base(name, desc)
    {
        MaxUses = 3;
        UsesLeft = MaxUses;
    }

    public void UseItem(IUnit unit)
    {
        if (unit!.Stat.HitPoints >= unit.Stat.MaxHitPoints)
        {
            Console.WriteLine($"{unit.Name} is already at max health.");
        }
        else
        {
            int preItemHP = unit.Stat.HitPoints;
            unit.Heal(10);
            int postItemHP = unit.Stat.MaxHitPoints;
            int healedHP = postItemHP - preItemHP;
            Console.WriteLine($"{unit.Name} used {Name} and gained {healedHP} hit points");
            UsesLeft--;

            if (UsesLeft == 0)
            {
                Console.WriteLine($"{unit.Name} used the last {Name} and it is now gone.");
                foreach (UnitItem unitItem in unit.UnitItems)
                {
                    if (unitItem.Item == this)
                    {
                        unit.UnitItems.Remove(unitItem);
                        break;
                    }
                }
            }
        }
    }

    public override string ToString()
    {
        return $"{Name} ({UsesLeft}/{MaxUses})";
    }
}
