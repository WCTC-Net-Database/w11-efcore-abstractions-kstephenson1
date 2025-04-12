using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Inventories;
using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.Units.Characters;

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
