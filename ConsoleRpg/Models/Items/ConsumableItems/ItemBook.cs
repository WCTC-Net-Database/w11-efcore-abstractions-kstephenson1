using ConsoleRPG.Models.Interfaces.ItemBehaviors;
using ConsoleRPG.Services.DataHelpers;

namespace ConsoleRPG.Models.Items.ConsumableItems;

public class ItemBook : ConsumableItem, IConsumableItem
{
    public override string ItemType { get; set; } = "ItemBook";
    public override int MaxUses { get; set ; } = 10;
    public ItemBook()
    {
        Name = "Book";
        Description = "Use to read the book.";
        MaxUses = 10;
        UsesLeft = MaxUses;
    }

    public ItemBook(string name, string desc) : base(name, desc)
    {
        MaxUses = 10;
        UsesLeft = MaxUses;
    }

    public void UseItem()
    {
        Console.WriteLine($"You read the book. Isn't there a battle going on right now!?");
    }

    public override string ToString()
    {
        return $"{Name} ({UsesLeft}/{MaxUses})";
    }
}
