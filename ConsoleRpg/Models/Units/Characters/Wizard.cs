using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using CsvHelper.Configuration.Attributes;
using ConsoleRPG.Models.Combat;
using ConsoleRPG.Models.Commands.UnitCommands;
using ConsoleRPG.Models.Interfaces.UnitClasses;
using ConsoleRPG.Models.Inventories;
using ConsoleRPG.Models.Units.Abstracts;

namespace ConsoleRPG.Models.Units.Characters;

public class Wizard : Character, IMage
{
    public override string UnitType { get; set; } = "Wizard";

    public Wizard()
    {

    }
    public Wizard(string name, string characterClass, int level, int hitPoints, Inventory inventory, Stat stats)
    {

    }

    [Ignore]
    [JsonIgnore]
    [NotMapped]
    public virtual CastCommand CastCommand { get; set; } = null!;

    public void Cast(string spellName)
    {
        CastCommand = new(this, spellName);
        Invoker.ExecuteCommand(CastCommand);
    }
}
