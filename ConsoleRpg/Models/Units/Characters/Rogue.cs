using ConsoleRPG.Models.Combat;
using ConsoleRPG.Models.Inventories;
using ConsoleRPG.Models.Units.Abstracts;

namespace ConsoleRPG.Models.Units.Characters;

public class Rogue : Character
{
    public override string UnitType { get; set; } = "Rogue";

    public Rogue()
    {

    }

    public Rogue(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stat stats)
    {

    }
}
