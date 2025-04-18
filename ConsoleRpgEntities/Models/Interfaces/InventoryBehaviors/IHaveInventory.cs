﻿using ConsoleRpgEntities.Models.Commands.Invokers;
using ConsoleRpgEntities.Models.Commands.ItemCommands;

namespace ConsoleRpgEntities.Models.Interfaces.InventoryBehaviors;

public interface IHaveInventory
{
    // Interface tha allows units to hold items.
    CommandInvoker Invoker { get; set; }
    DropItemCommand DropItemCommand { get; set; }
    TradeItemCommand TradeItemCommand { get; set; }
    List<UnitItem> UnitItems { get; set; }
    void DropItem(IItem item);
    void TradeItem(IItem item, IUnit target);
}
