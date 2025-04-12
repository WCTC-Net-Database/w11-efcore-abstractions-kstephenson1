using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Inventories;
using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.Units.Monsters;

public class EnemyGoblin : Monster
{
    public override string UnitType { get; set; } = "EnemyGoblin";
    public EnemyGoblin()
    {

    }

    public EnemyGoblin(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stat stats)
    {

    }
}
