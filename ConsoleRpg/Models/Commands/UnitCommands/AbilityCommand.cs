using ConsoleRPG.Models.Abilities;
using ConsoleRPG.Models.Combat;
using ConsoleRPG.Models.Interfaces;
using ConsoleRPG.Models.Interfaces.Commands;
using ConsoleRPG.Models.Interfaces.UnitBehaviors;
using ConsoleRPG.Models.Items.WeaponItems;

namespace ConsoleRPG.Models.Commands.UnitCommands;

public class AbilityCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.
    private readonly IUnit _unit;
    private readonly Ability _ability;

    public AbilityCommand()
    {
        
    }
    public AbilityCommand(IUnit unit, Ability ability)
    {
        if (unit == null)
            return;
        _unit = unit;
        _ability = ability;
    }
    public void Execute()
    {
        if (_unit.Abilities.Contains(_ability))
        {
            Console.WriteLine($"{_unit.Name} uses ability {_ability.Name}.");
        }
        else
        {
            Console.WriteLine($"{_unit.Name} does not have ability {_ability.Name}.");
        }
        
    }
}