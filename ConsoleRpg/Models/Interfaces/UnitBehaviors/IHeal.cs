using ConsoleRPG.Models.Commands.Invokers;
using ConsoleRPG.Models.Commands.UnitCommands;

namespace ConsoleRPG.Models.Interfaces.UnitBehaviors;

public interface IHeal
{
    // Interface tha allows units to heal.
    CommandInvoker Invoker { set; get; }
    HealCommand HealCommand { set; get; }

    void Heal(IUnit target);
}
