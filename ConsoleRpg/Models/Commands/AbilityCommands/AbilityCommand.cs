using ConsoleRpg.Models.Abilities;
using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Interfaces.Commands;
using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.Commands.AbilityCommands;

public class AbilityCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.
    private readonly IUnit _unit;
    private readonly IUnit _target;
    private readonly Ability _ability;

    public AbilityCommand()
    {
        
    }
    public AbilityCommand(IUnit unit, IUnit target, Ability ability)
    {
        if (unit == null || target == null)
            return;
        _unit = unit;
        _target = target;
        _ability = ability;
    }
    public void Execute()
    {
        if (_unit.Abilities.Contains(_ability))
        {
            Console.WriteLine($"{_unit.Name} uses ability {_ability.Name}.");
            _ability.Execute((Unit)_unit, (Unit)_target);
        }
        else
        {
            Console.WriteLine($"{_unit.Name} does not have ability {_ability.Name}.");
        }
        
    }
}