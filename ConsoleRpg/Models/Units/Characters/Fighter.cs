using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Inventories;
using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.Units.Characters;

public class Fighter : Character
{
    public override string UnitType { get; set; } = "Fighter";

    public Fighter()
    {

    }
    public Fighter(string name, string characterClass, int level, Inventory inventory, Stat stats)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        Inventory = inventory;
        Stat = stats;
        Inventory.Unit = this;
    }
}
