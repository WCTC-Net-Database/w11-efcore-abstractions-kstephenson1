using ConsoleRpg.Models.Commands.Invokers;
using ConsoleRpg.Models.Commands.ItemCommands;
using ConsoleRpg.Models.Items;

namespace ConsoleRpg.Models.Interfaces.InventoryBehaviors;

public interface IHaveInventory
{
    // Interface tha allows units to hold items.
    CommandInvoker Invoker { get; set; }
    DropItemCommand DropItemCommand { get; set; }
    TradeItemCommand TradeItemCommand { get; set; }
    List<Item> Items { get; set; }
    void DropItem(IItem item);
    void TradeItem(IItem item, IUnit target);
}
