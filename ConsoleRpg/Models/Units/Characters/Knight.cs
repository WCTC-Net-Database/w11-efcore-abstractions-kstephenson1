using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.Units.Characters;

public class Knight : Character
{
    public override string UnitType { get; set; } = "Knight";

    public Knight()
    {

    }
}
