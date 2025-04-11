using ConsoleRPG.Models.Commands.Invokers;
using ConsoleRPG.Models.Commands.UnitCommands;

namespace ConsoleRPG.Models.Interfaces.UnitBehaviors;

public interface IShootable
{
    // Interface tha allows units to shoot.
    CommandInvoker Invoker { set; get; }
    ShootCommand ShootCommand { set; get; }
    void Shoot(IUnit target);
}
