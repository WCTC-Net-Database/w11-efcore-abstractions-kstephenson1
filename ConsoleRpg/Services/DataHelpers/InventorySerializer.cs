namespace ConsoleRpg.Services.DataHelpers;

using System.Collections.Generic;
using ConsoleRpg.DataTypes;
using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Inventories;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Models.Items.ConsumableItems;
using ConsoleRpg.Models.Items.EquippableItems.WeaponItems;
using ConsoleRpg.Models.Items.WeaponItems;

public class InventorySerializer
{
    // InventorySerializer contains fuctions to turn a string into List<Item> to Inventories and vice versa.
    public static Inventory Deserialize(string inventoryString)         // Converts String into Inventories
    {
        List<string> items = ToStringList(inventoryString);
        return DeserializeList(items);
    }

    public static string? Serialize(Inventory inventory)                // Converts Inventories into String
    {
        return ToString(ToItemList(inventory)!);
    }

    public static Inventory DeserializeList(List<string> itemArray)     // Converts String into Inventories
    {
        Inventory inventory = new();
        foreach (string item in itemArray)
        {
            var convertedItem = ConvertToItem(item);
            inventory.Items!.Add(convertedItem as Item);
        }
        return inventory;
    }

    public static List<string>? SerializeList(Inventory inventory)      // Converts Inventories into String
    {
        List<string> itemArray = new();
        foreach (IItem item in inventory.Items!)
        {
            itemArray.Add(StringHelper.ToItemIdFormat(item.Name));
        }
        return itemArray;
    }

    private static List<string> ToStringList(string itemString)             //Converts String into List<string>
    {
        string[] items = itemString.Split('|');
        return items.ToList();
    }

    private static string ToString(List<IItem> items)                    // Converts List<Item> to String
    {
        if (items == null)
            return "";
        else
        {
            string inventory = "";

            foreach (IItem item in items)
            {
                if (inventory == "")
                    inventory += StringHelper.ToItemIdFormat(item.Name);
                else
                    inventory += "|" + StringHelper.ToItemIdFormat(item.Name);
            }

            return inventory;
        }
    }

    private static List<IItem>? ToItemList(Inventory inventory)          // Converts Inventories to List<Item>
    {
        List<IItem?> items = new List<IItem?>();
        foreach (IItem item in inventory.Items!)
        {
            items.Add(item);
        }
        return items;
    }

    private static IItem ConvertToItem(string itemString)
    {
        return itemString switch
        {
            // Weapons
            "dagger" => new PhysicalWeaponItem("Dagger", WeaponType.Sword, Rank.E, 45, 4, 80, 0, 1, 4, 1),
            "mace" => new PhysicalWeaponItem("Mace", WeaponType.Axe, Rank.E, 45, 4, 80, 0, 1, 4, 1),
            "staff" => new PhysicalWeaponItem("Staff", WeaponType.Lance, Rank.E, 45, 4, 80, 0, 1, 4, 1),
            "sword" => new PhysicalWeaponItem("Sword", WeaponType.Sword, Rank.E, 45, 4, 80, 0, 1, 4, 1),
            "bow" => new PhysicalWeaponItem("Bow", WeaponType.Bow, Rank.E, 45, 6, 70, 0, 2, 4, 1),

            "book_lightning" => new MagicWeaponItem("Lightning", WeaponType.Elemental, Rank.E, 30, 5, 80, 5, 2, 4, 1),
            "book_decay" => new MagicWeaponItem("Decay", WeaponType.Dark, Rank.E, 30, 10, 60, 0, 2, 4, 1),
            "book_smite" => new MagicWeaponItem("Smite", WeaponType.Light, Rank.E, 30, 4, 100, 15, 2, 4, 1),

            // Monster Only Weapons
            "ghostly_axe" => new PhysicalWeaponItem("Ghostly Axe", WeaponType.Axe, Rank.E, 45, 6, 70, 2, 1, 0, 1),

            // Consumables
            "potion" => new ItemPotion(),
            //"book" => new ItemBook(),
            "lockpick" => new ItemLockpick(),

            "shield" => new GenericItem(itemString),
            "robe" => new GenericItem(itemString),
            "horse" => new GenericItem(itemString),
            "cloak" => new GenericItem(itemString),
            "armor" => new GenericItem(itemString),

            _ => throw new ArgumentOutOfRangeException($"Item name out of range when converting from json: {itemString}")
        };
    }
}
