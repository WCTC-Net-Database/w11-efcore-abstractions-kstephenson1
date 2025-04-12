using ConsoleRpg.Models.Commands.Invokers;
using ConsoleRpg.Models.Commands.ItemCommands;

namespace ConsoleRpg.Models.Interfaces.UnitBehaviors;

public interface IUseItems
{
    // Interface tha allows units to hold items.
    CommandInvoker Invoker { get; set; }
    UseItemCommand UseItemCommand { get; set; }
    void UseItem(IItem item);
}
