using ConsoleRPG.Models.Combat;
using ConsoleRPG.Models.Inventories;
using ConsoleRPG.Models.Units.Abstracts;

namespace ConsoleRPG.Models.Units.Monsters;

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
