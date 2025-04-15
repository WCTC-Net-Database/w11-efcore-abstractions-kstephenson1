using ConsoleRpgEntities.DataTypes;
using ConsoleRpgEntities.Models.Interfaces;
using ConsoleRpgEntities.Models.Interfaces.ItemBehaviors;

namespace ConsoleRpgEntities.Models.UI.Menus.InteractiveMenus;

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

        foreach (UnitItem unitItem in unit.UnitItems!)
        {
            if (unitItem.Item is IConsumableItem consumableItem)
            {
                AddMenuItem($"{consumableItem.Name}", $"[[{consumableItem.UsesLeft}/{consumableItem.MaxUses}]] {consumableItem.Description}", unitItem.Item);
            }
            else if (unitItem.Item is IEquippableItem equippableItem)
            {
                if (InventoryHelper.IsItemEquipped(unit, equippableItem))
                {
                    AddMenuItem($"{equippableItem.Name}", $"[[E]] [[{equippableItem.Durability}/{equippableItem.MaxDurability}]] {equippableItem.Description}", unitItem.Item);
                }
                else
                {
                    AddMenuItem($"{equippableItem.Name}", $"[[{equippableItem.Durability}/{equippableItem.MaxDurability}]] {equippableItem.Description}", unitItem.Item);
                }
            }
            else
            {
                AddMenuItem(unitItem.Item.Name, unitItem.Item.Description, unitItem.Item);
            }
        }
        AddMenuItem(exitMessage, "", null!);
    }
}

