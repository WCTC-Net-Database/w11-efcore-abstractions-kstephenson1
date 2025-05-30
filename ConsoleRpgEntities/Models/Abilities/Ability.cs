﻿using ConsoleRpgEntities.Models.Units.Abstracts;

namespace ConsoleRpgEntities.Models.Abilities;

public abstract class Ability
{
    // Ability is an abstract class that holds basic ability properties and functions.
    public int AbilityId { get; set; }
    public abstract string AbilityType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual List<Unit> Units { get; }
    public Ability() { }

    public Ability(string name, string description)
    {
        Name = name;
        Description = description;
    }

    /// <summary>
    /// CanUseAbility checks to see if the unit can use the ability.
    /// </summary>
    /// <param name="unit"></param>
    /// <returns></returns>
    public bool CanUseAbility(Unit unit)
    {
        if (unit.Abilities.Contains(this))
            return true;
        return false;
    }

    /// <summary>
    /// Execute is triggered when the ability is used.
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="target"></param>
    public abstract void Execute(Unit unit, Unit target);
}
