using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using ConsoleRpgEntities.Models.Units.Abstracts;

namespace ConsoleRpgEntities.Models.Abilities;

public abstract class Ability
{
    public int AbilityId { get; set; }
    public abstract string AbilityType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual List<Unit> Units { get; }
    public Ability()
    {
        
    }
    public Ability(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public bool CanUseAbility(Unit unit)
    {
        if(unit.Abilities.Contains(this))
            return true;
        return false;
    }

    public abstract void Execute(Unit unit, Unit target);
}
