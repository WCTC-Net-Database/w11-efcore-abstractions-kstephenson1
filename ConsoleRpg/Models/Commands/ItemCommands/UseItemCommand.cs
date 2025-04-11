using ConsoleRPG.Models.Interfaces;
using ConsoleRPG.Models.Interfaces.Commands;
using ConsoleRPG.Models.Interfaces.ItemBehaviors;

namespace ConsoleRPG.Models.Commands.ItemCommands;

public class UseItemCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.

    private readonly IItem _item;
    public UseItemCommand(IItem item)
    {
        _item = item;
    }
    public void Execute()
    {
        if (_item is IConsumableItem consumableItem)
        {
            consumableItem.UseItem();
        }
        else
        {
            Console.WriteLine("This item is not usable.");
        }

    }
}
