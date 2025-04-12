using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using CsvHelper.Configuration.Attributes;
using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Commands.UnitCommands;
using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Interfaces.UnitClasses;
using ConsoleRpg.Models.Inventories;
using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.Units.Monsters;

public class EnemyArcher : Monster, IArcher
{
    public override string UnitType { get; set; } = "EnemyArcher";

    public EnemyArcher()
    {

    }

    public EnemyArcher(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stat stats)
    {

    }

    [Ignore]
    [JsonIgnore]
    [NotMapped]
    public virtual ShootCommand ShootCommand { get; set; }

    public void Shoot(IUnit target)
    {
        ShootCommand = new(this, target);
        Invoker.ExecuteCommand(ShootCommand);
    }

    public override void Attack(IUnit target) => Shoot(target);
}
