﻿using ConsoleRpg.Models.Commands.ItemCommands;
using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Interfaces.Commands;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;

namespace ConsoleRpg.Models.UI.Menus.InteractiveMenus;

public class ItemCommandMenu : InteractiveSelectionMenu<ICommand>
{

    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.

    public override void Display(string errorMessage)
    {
        throw new ArgumentException("CommandMenu(unit, prompt) requires a unit.");
    }

    public ICommand Display(IUnit unit, IItem item, string prompt, string exitMessage)
    {
        ICommand selection = default!;
        bool exit = false;
        while (exit != true)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            Update(unit, item, exitMessage);
            BuildTable(exitMessage);
            Show();
            ConsoleKey key = ReturnValidKey();
            selection = DoKeyActionReturnUnit(key, out exit);
        }
        return selection;
    }

    public override void Update(string exitMessage)
    {
        throw new ArgumentException("Update(item) requires an item.");
    }

    public void Update(IUnit unit, IItem item, string exitMessage)
    {
        _menuItems = new();

        AddMenuItem($"Drop Item", $"Get rid of the item forever.", new DropItemCommand(null!, null!));
        AddMenuItem($"Trade Item", $"Gives this item to someone else.", new TradeItemCommand(null!, null!, null!));

        if (item is IConsumableItem consumableItem)
        {
            AddMenuItem($"Use Item", $"{consumableItem.Description}", new UseItemCommand(null!, null!));
        }

        if (item is IEquippableItem equippableItem)
        {
            if (InventoryHelper.IsItemEquipped(unit, equippableItem))
            {
                AddMenuItem($"[dim]Equip Item[/]", $"[[{equippableItem.Durability}/{equippableItem.MaxDurability}]] {equippableItem.Description}", null!);
            }
            else
            {
                AddMenuItem($"Equip Item", $"[[{equippableItem.Durability}/{equippableItem.MaxDurability}]] {equippableItem.Description}", new EquipCommand(null!, null!));
            }
        }

        AddMenuItem(exitMessage, "", null!);
    }
}

