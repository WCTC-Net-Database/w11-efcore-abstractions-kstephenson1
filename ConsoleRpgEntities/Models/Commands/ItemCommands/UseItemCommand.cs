using ConsoleRpgEntities.Models.Interfaces;
using ConsoleRpgEntities.Models.Interfaces.Commands;
using ConsoleRpgEntities.Models.Interfaces.ItemBehaviors;

namespace ConsoleRpgEntities.Models.Commands.ItemCommands;

public class UseItemCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.

    private readonly IUnit _unit;
    private readonly IItem _item;
    public UseItemCommand(IUnit unit, IItem item)
    {
        _unit = unit;
        _item = item;
    }
    public void Execute()
    {
        if (_item is IConsumableItem consumableItem)
        {
            consumableItem.UseItem(_unit);
        }
        else
        {
            Console.WriteLine("This item is not usable.");
        }

    }
}
