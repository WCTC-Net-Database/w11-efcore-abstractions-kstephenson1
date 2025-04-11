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

public class EnemyCleric : Monster, ICleric
{
    public override string UnitType { get; set; } = "EnemyCleric";
    public EnemyCleric()
    {

    }

    public EnemyCleric(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stat stats)
    {

    }

    [Ignore]
    [JsonIgnore]
    [NotMapped]
    public virtual HealCommand HealCommand { get; set; } = null!;

    [Ignore]
    [JsonIgnore]
    [NotMapped]
    public virtual CastCommand CastCommand { get; set; } = null!;

    public void Heal(IUnit target)
    {
        HealCommand = new(this, target);
        Invoker.ExecuteCommand(HealCommand);
    }
    public void Cast(string spellName)
    {
        CastCommand = new(this, spellName);
        Invoker.ExecuteCommand(CastCommand);

    }
}
