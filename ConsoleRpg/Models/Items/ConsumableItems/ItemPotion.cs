using ConsoleRPG.Models.Interfaces.ItemBehaviors;
using ConsoleRPG.Services.DataHelpers;

namespace ConsoleRPG.Models.Items.ConsumableItems;

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

    public void UseItem()
    {
        if (Inventory.Unit!.Stat.HitPoints >= Inventory.Unit.Stat.MaxHitPoints)
        {
            Console.WriteLine($"{Inventory.Unit.Name} is already at max health.");
        }
        else
        {
            int preItemHP = Inventory.Unit.Stat.HitPoints;
            Inventory.Unit.Heal(10);
            int postItemHP = Inventory.Unit.Stat.MaxHitPoints;
            int healedHP = postItemHP - preItemHP;
            Console.WriteLine($"{Inventory.Unit.Name} used {Name} and gained {healedHP} hit points");
            UsesLeft--;

            if (UsesLeft == 0)
            {
                Inventory.RemoveItem(this);
            }
        }
    }

    public override string ToString()
    {
        return $"{Name} ({UsesLeft}/{MaxUses})";
    }
}
