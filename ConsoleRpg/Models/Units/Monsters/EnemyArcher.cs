using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using CsvHelper.Configuration.Attributes;
using ConsoleRPG.Models.Combat;
using ConsoleRPG.Models.Commands.UnitCommands;
using ConsoleRPG.Models.Interfaces;
using ConsoleRPG.Models.Interfaces.UnitClasses;
using ConsoleRPG.Models.Inventories;
using ConsoleRPG.Models.Units.Abstracts;

namespace ConsoleRPG.Models.Units.Monsters;

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
