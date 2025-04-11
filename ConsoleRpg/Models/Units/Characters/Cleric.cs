using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ConsoleRPG.Models.Combat;
using ConsoleRPG.Models.Commands.UnitCommands;
using ConsoleRPG.Models.Interfaces;
using ConsoleRPG.Models.Interfaces.UnitClasses;
using ConsoleRPG.Models.Inventories;
using ConsoleRPG.Models.Units.Abstracts;

namespace ConsoleRPG.Models.Units.Characters;

public class Cleric : Character, ICleric
{
    public override string UnitType { get; set; } = "Cleric";

    public Cleric()
    {

    }
    public Cleric(string name, string characterClass, int level, Inventory inventory, Stat stats)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        Inventory = inventory;
        Stat = stats;
        Inventory.Unit = this;
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
