using ConsoleRpg.DataTypes;
using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Models.Items.WeaponItems;
using ConsoleRpg.Models.Units.Abstracts;

namespace ConsoleRpg
{
    public static class InventoryHelper
    {
        public static IEquippableWeapon? GetEquippedWeapon(Unit unit)
        {
            //foreach(Item item in unit.Items)
            //{
            //    if (item is IEquippableWeapon weaponItem && weaponItem.IsEquipped())
            //    {
            //        return weaponItem;
            //    }
            //}
            return null;
        }

        public static IEquippableArmor? GetEquippedArmorInSlot(Unit unit, ArmorType armorType)
        {
            foreach(Item item in unit.Items)
            {
                if (item is IEquippableArmor armorItem && unit.Items.Contains(item) && armorItem.ArmorType == armorType)
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

        public static bool IsInventoryFull(IUnit unit)
        {
            throw new NotImplementedException();
        }

        public static bool IsItemEquipped(IUnit unit, IEquippableItem equippableItem)
        {
            foreach (Item item in unit.Items)
            {
                if (item is IEquippableItem equippedItem)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
