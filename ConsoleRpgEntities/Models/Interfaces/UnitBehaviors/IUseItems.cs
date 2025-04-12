using ConsoleRpgEntities.Models.Commands.Invokers;
using ConsoleRpgEntities.Models.Commands.ItemCommands;
using ConsoleRpgEntities.Models.Interfaces;

namespace ConsoleRpgEntities.Models.Interfaces.UnitBehaviors;

public interface IUseItems
{
    // Interface tha allows units to hold items.
    CommandInvoker Invoker { get; set; }
    UseItemCommand UseItemCommand { get; set; }
    void UseItem(IItem item);
}
