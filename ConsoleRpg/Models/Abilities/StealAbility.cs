using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.Abilities;

public class StealAbility : Ability
{
    public override string AbilityType { get; set; } = "StealAbility";

    public StealAbility()
    {
        Name = "Steal";
        Description = "Steals an item from an enemy.";
    }


    public override void Execute(Unit unit, Unit target)
    {
        if(CanUseAbility(unit))
        {
            Console.WriteLine($"{unit.Name} steals an item from {target.Name}.");
        }
        else
        {
            Console.WriteLine($"{unit.Name} does not have the ability to steal.");
        }
    }
}
