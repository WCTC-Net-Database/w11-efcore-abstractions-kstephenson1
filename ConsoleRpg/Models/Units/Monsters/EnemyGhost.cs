using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using CsvHelper.Configuration.Attributes;
using ConsoleRPG.Models.Combat;
using ConsoleRPG.Models.Commands.UnitCommands;
using ConsoleRPG.Models.Interfaces.UnitBehaviors;
using ConsoleRPG.Models.Inventories;
using ConsoleRPG.Models.Units.Abstracts;

namespace ConsoleRPG.Models.Units.Monsters;

public class EnemyGhost : Monster, IFlyable
{
    public override string UnitType { get; set; } = "EnemyGhost";
    public EnemyGhost()
    {

    }

    public EnemyGhost(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stat stats)
    {

    }

    [Ignore]
    [JsonIgnore]
    [NotMapped]
    public virtual FlyCommand FlyCommand { get ; set ; } = null!;

    public void Fly()
    {
        FlyCommand = new(this);
        Invoker.ExecuteCommand(FlyCommand);
    }

    public override void Move() => Fly();

}
