using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using CsvHelper.Configuration.Attributes;
using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Commands.UnitCommands;
using ConsoleRpg.Models.Interfaces.UnitClasses;
using ConsoleRpg.Models.Inventories;
using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.Units.Characters;

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
