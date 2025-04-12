using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Inventories;
using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.Units.Monsters;

public class EnemyGhost : Monster
{
    public override string UnitType { get; set; } = "EnemyGhost";
    public EnemyGhost()
    {

    }

    public EnemyGhost(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stat stats)
    {

    }
}
