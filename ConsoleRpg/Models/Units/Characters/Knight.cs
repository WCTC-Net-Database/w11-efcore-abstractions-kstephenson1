using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Inventories;
using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.Units.Characters;

public class Knight : Character
{
    public override string UnitType { get; set; } = "Knight";

    public Knight()
    {

    }

    public Knight(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stat stats)
    {
        
    }
}
