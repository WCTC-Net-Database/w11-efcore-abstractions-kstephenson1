using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;
using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg.Models.UI.Menus.InteractiveMenus;

public class InventoryMenu : InteractiveSelectionMenu<IItem>
{

    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.

    public override void Display(string errorMessage)
    {
        throw new ArgumentException("CommandMenu(unit, prompt) requires a unit.");
    }

    public IItem Display(IUnit unit, string prompt, string exitMessage)
    {
        IItem selection = default!;
        bool exit = false;
        while (exit != true)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            Update(unit, exitMessage);
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

    public void Update(IUnit unit, string exitMessage)
    {
        _menuItems = new();

        foreach (IItem item in unit.Inventory.Items!)
        {
            if (item is IConsumableItem consumableItem)
            {
                AddMenuItem($"{consumableItem.Name}", $"[[{consumableItem.UsesLeft}/{consumableItem.MaxUses}]] {consumableItem.Description}", item);
            }
            else if (item is IEquippableItem weaponItem)
            {
                unit.Inventory.HasWeaponEquipped();
                if (weaponItem == unit.Inventory.EquippedWeapon)
                {
                    AddMenuItem($"{weaponItem.Name}", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description} (Equipped)", item);
                }
                else
                {
                    AddMenuItem($"{weaponItem.Name}", $"[[{weaponItem.Durability}/{weaponItem.MaxDurability}]] {weaponItem.Description}", item);
                }
            }
            else
            {
                AddMenuItem(item.Name, item.Description, item);
            }
        }
        AddMenuItem(exitMessage, "", null!);
    }
}

