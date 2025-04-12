using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Commands.UnitCommands;
using ConsoleRpg.Models.Interfaces.UnitClasses;
using ConsoleRpg.Models.Units.Abstracts;
using CsvHelper.Configuration.Attributes;

namespace ConsoleRpg.Models.Units.Characters;

public class Cleric : Character, ICleric
{
    public override string UnitType { get; set; } = "Cleric";

    public Cleric()
    {
        
    }
    //public Cleric(string name, string characterClass, int level, Inventory inventory, Stat stats)
    //{
    //    Name = name;
    //    Class = characterClass;
    //    Level = level;
    //    Inventory = inventory;
    //    Stat = stats;
    //    Inventory.Unit = this;
    //}

    [NotMapped]
    public virtual CastCommand CastCommand { get; set; } = null!;

    public void Cast(string spellName)
    {
        CastCommand = new(this, spellName);
        Invoker.ExecuteCommand(CastCommand);
    }
}
