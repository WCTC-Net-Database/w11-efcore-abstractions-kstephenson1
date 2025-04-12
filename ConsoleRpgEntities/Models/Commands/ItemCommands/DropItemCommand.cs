using ConsoleRpgEntities.Models.Items;
using ConsoleRpgEntities.Models.Interfaces;
using ConsoleRpgEntities.Models.Interfaces.Commands;

namespace ConsoleRpgEntities.Models.Commands.ItemCommands;

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
        foreach (UnitItem unitItem in _unit.UnitItems)
        {
            if (unitItem.Item == _item)
            {
                _unit.UnitItems.Remove(unitItem);
                break;
            }
        }
    }
}
