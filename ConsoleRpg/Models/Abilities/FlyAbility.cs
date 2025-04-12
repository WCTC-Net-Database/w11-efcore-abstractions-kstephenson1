using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.Abilities;

public class FlyAbility : Ability
{
    public override string AbilityType { get; set; } = "FlyAbility";

    public FlyAbility()
    {
        Name = "Fly";
        Description = "Flies to a location within flight range.";
    }


    public override void Execute(Unit unit, Unit target)
    {
        if(CanUseAbility(unit))
        {
            Console.WriteLine($"{unit.Name} flies.");
        }
        else
        {
            Console.WriteLine($"{unit.Name} does not have the ability to fly.");
        }
    }
}
