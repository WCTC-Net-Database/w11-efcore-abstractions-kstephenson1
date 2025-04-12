﻿using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Interfaces.Commands;
using ConsoleRpg.Models.Interfaces.UnitBehaviors;
using ConsoleRpg.Models.Items.EquippableItems.WeaponItems;

namespace ConsoleRpg.Models.Commands.UnitCommands;

public class ShootCommand : ICommand
{
    // The ShootCommand takes an attacking unit and a target, checks to see if the unit is able to shoot, then shoots at the target if available,
    // using an Encounter to calculate the damage and hit/crit chances.

    private readonly IUnit _unit;
    private readonly IUnit _target;
    private readonly Encounter _encounter;
    public ShootCommand()
    {
        
    }
    public ShootCommand(IUnit unit, IUnit target)
    {
        _unit = unit;
        _target = target;
        _encounter = new(unit, target);
    }

    public void Execute()
    {
        if (_unit is IShootable)
        {
            if (_unit != _target)
            {


                if (_encounter.Unit.GetEquippedWeapon() is PhysicalWeaponItem)
                {
                    Console.WriteLine($"{_unit.Name} attacks {_target.Name} with {_encounter.Unit.GetEquippedWeapon().Name}\n");
                    Console.WriteLine($"Hit Chance: {_encounter.GetDisplayedHit()}");
                    Console.WriteLine($"Critical Strike Chance: {_encounter.GetDisplayedCrit()}");
                    Console.WriteLine($"{_unit.Name}'s Damage: {_encounter.GetAttack()}");
                    Console.WriteLine($"{_target.Name}'s Defense: {_encounter.GetPhysicalResiliance(_target)}");
                }
                else if (_encounter.Unit.GetEquippedWeapon() is MagicWeaponItem)
                {
                    Console.WriteLine($"{_unit.Name} casts {_encounter.Unit.GetEquippedWeapon().Name} at {_target.Name}\n");
                    Console.WriteLine($"Hit Chance: {_encounter.GetDisplayedHit()}");
                    Console.WriteLine($"Critical Strike Chance: {_encounter.GetDisplayedCrit()}");
                    Console.WriteLine($"{_unit.Name}'s Magic Damage: {_encounter.GetMagicAttack()}");
                    Console.WriteLine($"{_target.Name}'s Resistance: {_encounter.GetMagicResiliance(_target)}\n");
                }

                Console.WriteLine($"{_unit.Name} rolls a : {_encounter.Roll}");

                if (_encounter.IsCrit())
                {
                    Console.WriteLine($"{_unit.Name} critically hit {_target.Name} for {_encounter.Damage} damage!");
                    _target.Damage(_encounter.Damage);
                }
                else if (_encounter.IsHit())
                {
                    Console.WriteLine($"{_unit.Name} hit {_target.Name} for {_encounter.Damage} damage.");
                    _target.Damage(_encounter.Damage);
                }
                else
                {
                    Console.WriteLine($"{_unit.Name}'s misses {_target.Name}");
                }
            }
            else
            {
                Console.WriteLine($"{_unit.Name} should not attack themselves.  That's not very nice!");
            }
        }
        else
        {
            Console.WriteLine($"{_unit} cannot attack.");
        }
    }
}
