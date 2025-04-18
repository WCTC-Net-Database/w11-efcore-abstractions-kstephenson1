using ConsoleRpgEntities.DataTypes;
using ConsoleRpgEntities.Models.Items.WeaponItems;

namespace ConsoleRpgEntities.Models.Items.EquippableItems.WeaponItems;

public class MagicWeaponItem : WeaponItem
{
    // MagicWeaponItem is a class that holds magic weapon item information
    public override string ItemType { get; set; } = "MagicWeaponItem";

    public MagicWeaponItem() { }

    public MagicWeaponItem(string name, WeaponType weaponType, Rank requiredRank, int maxDurability, int might,
        int hit, int crit, int range, int weight, int expModifier)
        : base(name, weaponType, requiredRank, maxDurability, might, hit, crit, range, weight, expModifier) { }
}
