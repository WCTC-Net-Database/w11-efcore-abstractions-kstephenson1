using ConsoleRPG.Models.Commands.Invokers;
using ConsoleRPG.Models.Commands.ItemCommands;

namespace ConsoleRPG.Models.Interfaces.UnitBehaviors;

public interface IUseItems
{
    // Interface tha allows units to hold items.
    CommandInvoker Invoker { get; set; }
    UseItemCommand UseItemCommand { get; set; }
    void UseItem(IItem item);
}
