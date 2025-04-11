using ConsoleRPG.Models.Combat;
using ConsoleRPG.Models.Interfaces;
using ConsoleRPG.Models.Interfaces.Commands;
using ConsoleRPG.Models.Interfaces.UnitBehaviors;

namespace ConsoleRPG.Models.Commands.UnitCommands;

public class HealCommand : ICommand
{
    // A generic attack command.  It takes in an attacking unit and a target, creates a new encounter object, and calculates whether or
    // not the unit hit/crit and calculates damage.  If the unit cannot attack, a message is provided to the user.

    private readonly IUnit _unit;
    private readonly IUnit _target;
    private readonly Encounter _encounter;
    public HealCommand()
    {
        
    }
    public HealCommand(IUnit unit, IUnit target)
    {
        _unit = unit;
        _target = target;
        _encounter = new(unit, target);
    }
    public void Execute()
    {
        if (_unit is IHeal)
        {
            if (_encounter.IsCrit())
            {
                Console.WriteLine($"{_unit.Name} critically heals {_target.Name} for {_encounter.Damage} hit points!");
                _target.Damage(_encounter.Damage * -1);
            }
            else if (_encounter.IsHit())
            {
                Console.WriteLine($"{_unit.Name} heals {_target.Name} for {_encounter.Damage} hit points.");
                _target.Damage(_encounter.Damage * -1);
            }
            else
            {
                Console.WriteLine($"{_unit.Name}'s misses {_target.Name}");
            }
        }
        else
        {
            Console.WriteLine($"{_unit} cannot heal.");
        }

    }
}
