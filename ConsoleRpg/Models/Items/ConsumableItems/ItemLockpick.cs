using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;
using ConsoleRpg.Services.DataHelpers;

namespace ConsoleRpg.Models.Items.ConsumableItems;

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
            unit.Items.Remove(this);
        }
    }
    public override string ToString()
    {
        return $"{Name} ({UsesLeft}/{MaxUses})";
    }
}
