using ConsoleRPG.Models.Combat;
using ConsoleRPG.Models.Inventories;
using ConsoleRPG.Models.Units.Abstracts;

namespace ConsoleRPG.Models.Units.Characters;

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
