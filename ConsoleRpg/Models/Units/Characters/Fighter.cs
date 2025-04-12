using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.Units.Characters;

public class Fighter : Character
{
    public override string UnitType { get; set; } = "Fighter";

    public Fighter()
    {

    }
}
