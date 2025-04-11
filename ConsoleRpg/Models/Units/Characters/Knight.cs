using ConsoleRPG.Models.Combat;
using ConsoleRPG.Models.Inventories;
using ConsoleRPG.Models.Units.Abstracts;

namespace ConsoleRPG.Models.Units.Characters;

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
