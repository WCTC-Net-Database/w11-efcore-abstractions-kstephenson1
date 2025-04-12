using ConsoleRpgEntities.Services.DataHelpers;
using ConsoleRpgEntities.Models.Interfaces;
using ConsoleRpgEntities.Models.Interfaces.ItemBehaviors;

namespace ConsoleRpgEntities.Models.Items.ConsumableItems;

public class ItemLockpick : ConsumableItem, IConsumableItem
{
    public override string ItemType { get; set; } = "ItemLockpick";

    public ItemLockpick()
    {
        Name = "Lockpick";
        Description = "Use to unlock a nearby door or chest.";
        MaxUses = 5;
        UsesLeft = MaxUses;
    }

    public ItemLockpick(string name, string desc) : base(name, desc)
    {
        MaxUses = 5;
        UsesLeft = MaxUses;
    }

    public void UseItem(IUnit unit)
    {
        Console.WriteLine($"{unit!.Name} unlocked something!");
        UsesLeft--;

        if (UsesLeft == 0)
        {
            Console.WriteLine($"The lockpick broke!");
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
    public override string ToString()
    {
        return $"{Name} ({UsesLeft}/{MaxUses})";
    }
}
