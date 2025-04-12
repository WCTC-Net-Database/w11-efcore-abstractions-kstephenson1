using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ConsoleRpg.DataTypes;
using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Models.Items.EquippableItems.ArmorItems;
using ConsoleRpg.Models.Items.WeaponItems;
using ConsoleRpg.Models.Units.Abstracts;
using ConsoleRpg.Services.DataHelpers;

namespace ConsoleRpg.Models.Inventories;
public class Inventory
{
    public int InventoryId { get; set; }
    // The Inventory class holds a list of equipped and held items.

    // The unit the inventory belongs to and it's unit id for fk purposes.
    [JsonIgnore]
    public Unit? Unit;
    public virtual int UnitId { get; set; }

    // EquippedWeapon holds the currently equipped weapon.
    //[ForeignKey("EquippedWeaponId")]
    public virtual WeaponItem? EquippedWeapon { get; set; }
    public int? EquippedWeaponId { get; set; }

    /* Equipped armor is an array that holds 4 items
     * [0] Head armor i.e. hoods, cowls, or helms
     * [1] Chest armor i.e. shirts, tunics, or plackarts
     * [2] Legs armor i.e. robes, pants or greaves
     * [3] Feet armor i.e. shoes, boots, or sabatons.
     */
    //[ForeignKey("EquippedHeadArmorId")]
    public virtual ArmorItem? EquippedHeadArmor { get; set; }
    public int? EquippedHeadArmorId { get; set; }
    //[ForeignKey("EquippedChestArmorId")]
    public virtual ArmorItem? EquippedChestArmor { get; set; }
    public int? EquippedChestArmorId { get; set; }
    //[ForeignKey("EquippedLegArmorId")]
    public virtual ArmorItem? EquippedLegArmor { get; set; }
    public int? EquippedLegArmorId { get; set; }
    //[ForeignKey("EquippedFeetArmorId")]
    public virtual ArmorItem? EquippedFeetArmor { get; set; }
    public int? EquippedFeetArmorId { get; set; }

    // A list of items held by the unit.  Equipped items will not show up in this list.
    public virtual List<Item>? Items { get; set; } = new();

    public Inventory()
    {

    }

    //public Inventory(List<IItem> items)
    //{
    //    EquippedArmor = new ArmorItem[4];

    //    foreach (IItem item in items)
    //    {
    //        Items.Add(item as Item);
    //    }
    //}

    public bool AddItem(IItem item)
    {
        if (Items!.Count < 5)
        {
            SetParentsInItem(item);
            Items!.Add(item as Item);
            return true;
        }
        return false;
    }

    public bool RemoveItem(IItem item)
    {
        try
        {
            Items!.Remove(item as Item);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool InventoryIsFull()
    {
        return Items!.Count >= 99;
    }

    public bool HasWeaponEquipped()
    {
        return EquippedWeapon != null;
    }

    public bool HasArmorEquipped()
    {
        foreach (ArmorType armorType in Enum.GetValues(typeof(ArmorType)))
        {
            if (HasArmorEquippedInSlot(armorType))
                return true;
        }
        return false;
    }

    public bool HasArmorEquippedInSlot(ArmorType armorType)
    {
        return armorType switch
        {
            ArmorType.Head => EquippedHeadArmor != null,
            ArmorType.Chest => EquippedChestArmor != null,
            ArmorType.Legs => EquippedLegArmor != null,
            ArmorType.Feet => EquippedFeetArmor != null,
            _ => throw new ArgumentOutOfRangeException($"Tried to check an armor type that doesn't exist. Armor type: {armorType}")
            };
    }

    public ArmorItem? GetArmorItemInSlot(ArmorType armorType)
    {
        return armorType switch
        {
            ArmorType.Head => EquippedHeadArmor,
            ArmorType.Chest => EquippedChestArmor,
            ArmorType.Legs => EquippedLegArmor,
            ArmorType.Feet => EquippedFeetArmor,
            _ => throw new ArgumentOutOfRangeException($"Tried to check an armor type that doesn't exist. Armor type: {armorType}")
        };
    }

    public bool TryEquipItem(IEquippableItem itemToEquip)
    {
        if(itemToEquip is WeaponItem weaponItem)
        {
            HasWeaponEquipped();
            if (EquippedWeapon != null && EquippedWeapon != itemToEquip)
            {
                Items!.Remove(weaponItem);
                Items.Insert(0,weaponItem);
                return true;
            }
        }
        else if(itemToEquip is ArmorItem armorItem)
        {
            foreach(ArmorType armorType in Enum.GetValues(typeof(ArmorType)))
            {
                if (armorItem.ArmorType == armorType)
                {
                    switch (armorType)
                    {
                        case ArmorType.Head:
                            EquippedHeadArmor = armorItem;
                            break;
                        case ArmorType.Chest:
                            EquippedChestArmor = armorItem;
                            break;
                        case ArmorType.Legs:
                            EquippedLegArmor = armorItem;
                            break;
                        case ArmorType.Feet:
                            EquippedFeetArmor = armorItem;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException($"Tried to check an armor type that doesn't exist. Armor type: {armorType}");
                    }
                }
            }
            HasArmorEquipped();
            if (EquippedWeapon != null && EquippedWeapon != itemToEquip)
            {
                Items!.Remove(armorItem);
                Items.Insert(0, armorItem);
                return true;
            }
        }
        return false;
    }

    public void DamageEquippedItem(int dmg)
    {
        if(HasWeaponEquipped())
        {
            EquippedWeapon.TakeDurabilityDamage(dmg);
        }
        else
        {
            throw new ArgumentOutOfRangeException("Tried to damage an item that isn't equipped.");
        }
    }

    //public List<IConsumableItem> GetConsumableItems()
    //{
    //    List<IConsumableItem> consumableItems = new();
    //    foreach (IItem item in Items!)
    //    {
    //        if (item is IConsumableItem)
    //        {
    //            consumableItems.Add((IConsumableItem)item);
    //        }
    //    }

    //    return consumableItems;
    //}

    private void SetParentsInItem(IItem item)
    {
        item.Inventory = this;
    }

    public override string ToString() => InventorySerializer.Serialize(this)!;
}
