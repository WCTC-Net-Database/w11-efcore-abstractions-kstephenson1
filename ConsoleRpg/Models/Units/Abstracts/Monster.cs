using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Inventories;

namespace ConsoleRpg.Models.Units.Abstracts;

public abstract class Monster : Unit
{
    // The Monster class is, for the most part, an abstract(ish) class that might contain some computer intelligence functions one day.
    public Monster() { }

    public Monster(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stat stats)
    {

    }
}
