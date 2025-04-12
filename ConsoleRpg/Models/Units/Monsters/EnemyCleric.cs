using System.ComponentModel.DataAnnotations.Schema;
using ConsoleRpg.Models.Commands.UnitCommands;
using ConsoleRpg.Models.Interfaces.UnitClasses;
using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.Units.Monsters;

public class EnemyCleric : Monster, ICleric
{
    public override string UnitType { get; set; } = "EnemyCleric";
    public EnemyCleric()
    {

    }

    [NotMapped]
    public virtual CastCommand CastCommand { get; set; } = null!;

    public void Cast(string spellName)
    {
        CastCommand = new(this, spellName);
        Invoker.ExecuteCommand(CastCommand);

    }
}
