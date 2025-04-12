using ConsoleRpgEntities.DataTypes;
using ConsoleRpgEntities.Models.Items.WeaponItems;

namespace ConsoleRpgEntities.Models.Items.EquippableItems.WeaponItems;

public class PhysicalWeaponItem : WeaponItem
{
    public override string ItemType { get; set; } = "PhysicalWeaponItem";

    // WeaponItem is a class that holds weapon item information

    public PhysicalWeaponItem()
    {
        
    }

    public PhysicalWeaponItem(string name, WeaponType weaponType, Rank requiredRank, int maxDurability, int might, int hit, int crit, int range, int weight, int expModifier) : base(name, weaponType, requiredRank, maxDurability, might, hit, crit, range, weight, expModifier)
    {

    }
}
