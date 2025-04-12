using ConsoleRpgEntities.Models.Commands.Invokers;
using ConsoleRpgEntities.Models.Commands.UnitCommands;
using ConsoleRpgEntities.Models.Interfaces;

namespace ConsoleRpgEntities.Models.Interfaces.UnitBehaviors;

public interface IShootable
{
    // Interface tha allows units to shoot.
    CommandInvoker Invoker { set; get; }
    ShootCommand ShootCommand { set; get; }
    void Shoot(IUnit target);
}
