using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Commands.Invokers;
using ConsoleRpg.Models.Commands.UnitCommands;

namespace ConsoleRpg.Models.Interfaces.UnitBehaviors;

public interface ICastable
{
    public Stat Stat { get; set; }
    // Interface tha allows units to cast spells.
    CommandInvoker Invoker { set; get; }
    CastCommand CastCommand { set; get; }
    void Cast(string spellName);
}
