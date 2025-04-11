using ConsoleRPG.Models.Combat;
using ConsoleRPG.Models.Commands.Invokers;
using ConsoleRPG.Models.Commands.UnitCommands;

namespace ConsoleRPG.Models.Interfaces.UnitBehaviors;

public interface ICastable
{
    public Stat Stat { get; set; }
    // Interface tha allows units to cast spells.
    CommandInvoker Invoker { set; get; }
    CastCommand CastCommand { set; get; }
    void Cast(string spellName);
}
