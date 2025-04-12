using System.Linq;
using ConsoleRpgEntities.DataTypes;
using ConsoleRpgEntities.Models.Items;
using ConsoleRpgEntities.Models.Items.WeaponItems;
using ConsoleRpgEntities.Models.Units.Abstracts;
using ConsoleRpgEntities.Models.Interfaces;
using ConsoleRpgEntities.Models.Interfaces.ItemBehaviors;

namespace ConsoleRpgEntities;

public static class InventoryHelper
{
    public static IEquippableWeapon? GetEquippedWeapon(Unit unit)
    {
        if (unit.UnitItems == null) return null;
        foreach (UnitItem unitItem in unit.UnitItems)
        {
            if (unitItem.Item is IEquippableWeapon weaponItem && unitItem.Slot == EquipmentSlot.Weapon)
            {
                return weaponItem;
            }
        }
        return null;
    }

    public static IEquippableArmor? GetEquippedArmorInSlot(Unit unit, ArmorType armorType)
    {
        if (unit.UnitItems == null) return null;
        foreach (UnitItem unitItem in unit.UnitItems)
        {
            if (unitItem.Item is IEquippableArmor armorItem && unitItem.Slot == GetEquipmentSlotFromArmorType(armorType))
            {
                return armorItem;
            }
        }
        return null;
    }

    public static void EquipItem(IUnit unit, IEquippableItem equippableItem)
    {
        throw new NotImplementedException();
    }

    public static void EquipItem(IUnit unit, IEquippableItem equippableItem, EquipmentSlot slot)
    {
        throw new NotImplementedException();
    }

    public static bool IsInventoryFull(IUnit unit)
    {
        throw new NotImplementedException();
    }

    public static bool IsItemEquipped(IUnit unit, IEquippableItem equippableItem)
    {
        foreach (UnitItem unitItem in unit.UnitItems)
        {
            if (unitItem.Item is IEquippableItem equippedItem)
            {
                return true;
            }
        }
        return false;
    }

    private static EquipmentSlot GetEquipmentSlotFromArmorType(ArmorType armorType)
    {
        return armorType switch
        {
            ArmorType.Head => EquipmentSlot.Head,
            ArmorType.Chest => EquipmentSlot.Chest,
            ArmorType.Legs => EquipmentSlot.Legs,
            ArmorType.Feet => EquipmentSlot.Feet,
            _ => throw new ArgumentOutOfRangeException($"Tried to get an equipment slot from an invalid armor type: {armorType}")
        };
    }

    public static List<Item> GetUnequippedItemsInInventory(IUnit unit)
    {
        List<Item> items = new();
        if (unit.UnitItems == null) return items;
        foreach (UnitItem unitItem in unit.UnitItems)
        {
            if (unitItem.Slot == EquipmentSlot.None)
            {
                items.Add(unitItem.Item);
            }
        }
        return items;
    }

    public static List<IEquippableArmor> GetEquippedArmor(IUnit unit)
    {
        List<IEquippableArmor> items = new();
        foreach (UnitItem unitItem in unit.UnitItems)
        {
            if (unitItem.Item is IEquippableArmor equippableArmor && unitItem.Slot != EquipmentSlot.None && unitItem.Slot != EquipmentSlot.Weapon)
            {
                items.Add(equippableArmor);
            }
        }
        return items;
    }
}

