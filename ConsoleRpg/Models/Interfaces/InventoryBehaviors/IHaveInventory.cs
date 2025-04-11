using ConsoleRPG.Models.Commands.Invokers;
using ConsoleRPG.Models.Commands.ItemCommands;
using ConsoleRPG.Models.Inventories;

namespace ConsoleRPG.Models.Interfaces.InventoryBehaviors;

public interface IHaveInventory
{
    // Interface tha allows units to hold items.
    CommandInvoker Invoker { get; set; }
    DropItemCommand DropItemCommand { get; set; }
    TradeItemCommand TradeItemCommand { get; set; }
    Inventory Inventory { get; set; }
    void DropItem(IItem item);
    void TradeItem(IItem item, IUnit target);
}
