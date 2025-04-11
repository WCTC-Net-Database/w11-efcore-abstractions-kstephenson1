using ConsoleRPG.Models.Commands.Invokers;
using ConsoleRPG.Models.Commands.UnitCommands;
namespace ConsoleRPG.Models.Interfaces.UnitBehaviors;

public interface IFlyable
{
    // Interface tha allows units to fly.
    CommandInvoker Invoker { set; get; }
    FlyCommand FlyCommand { set; get; }
    void Fly();
}
