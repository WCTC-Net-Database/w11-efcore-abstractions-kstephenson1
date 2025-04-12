using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Interfaces.Commands;

namespace ConsoleRpg.Models.Commands.ItemCommands;

public class DropItemCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.

    private readonly IUnit _unit;
    private readonly IItem _item;

    public DropItemCommand(IUnit unit, IItem item)
    {
        _unit = unit;
        _item = item;
    }
    public void Execute()
    {
        Console.WriteLine($"{_unit.Name} threw away {_item.Name}.");
        _unit.Inventory.RemoveItem(_item);
    }
}
