using ConsoleRpg.Models.Commands.Invokers;
using ConsoleRpg.Models.Commands.UnitCommands;

namespace ConsoleRpg.Models.Interfaces.UnitBehaviors;

public interface IShootable
{
    // Interface tha allows units to shoot.
    CommandInvoker Invoker { set; get; }
    ShootCommand ShootCommand { set; get; }
    void Shoot(IUnit target);
}
