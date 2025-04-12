using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Interfaces.Commands;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;

namespace ConsoleRpg.Models.Commands.ItemCommands;

public class EquipCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.

    private readonly IUnit _unit;
    private readonly IEquippableItem _item;
    public EquipCommand(IUnit unit, IEquippableItem item)
    {
        _unit = unit;
        _item = item;
    }
    public void Execute()
    {
        Console.WriteLine($"{_unit.Name} equipped {_item.Name}");
        InventoryHelper.EquipItem(_unit, _item);
    }
}
