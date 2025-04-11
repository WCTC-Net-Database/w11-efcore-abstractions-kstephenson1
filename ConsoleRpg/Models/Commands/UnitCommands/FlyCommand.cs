using ConsoleRPG.Models.Interfaces;
using ConsoleRPG.Models.Interfaces.Commands;
using ConsoleRPG.Models.Interfaces.UnitBehaviors;

namespace ConsoleRPG.Models.Commands.UnitCommands;

public class FlyCommand : ICommand
{
    // FlyCommand takes in a unit and a position, checks to see if the unit is able to fly, then flies to the position if able.

    private readonly IUnit _unit;

    public FlyCommand()
    {

    }
    public FlyCommand(IUnit unit)
    {
        _unit = unit;
    }
    public void Execute()
    {
        if (_unit is IFlyable)
        {
            Console.WriteLine($"{_unit.Name} flies.");
        }
        else
        {
            Console.WriteLine($"{_unit.Name} cannot fly.");
        }
    }
}
