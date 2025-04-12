using ConsoleRpg.DataTypes;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;
using ConsoleRpg.Models.Items.WeaponItems;

namespace ConsoleRpg.Models.Items.EquippableItems.WeaponItems;

public class MagicWeaponItem : WeaponItem
{
    public override string ItemType { get; set; } = "MagicWeaponItem";

    // WeaponItem is a class that holds weapon item information

    public MagicWeaponItem()
    {
        
    }

    public MagicWeaponItem(string name, WeaponType weaponType, Rank requiredRank, int maxDurability, int might, int hit, int crit, int range, int weight, int expModifier) : base(name, weaponType, requiredRank, maxDurability, might, hit, crit, range, weight, expModifier)
    {

    }

    public override string ToString()
    {
        return $"[[{Durability}/{MaxDurability}]] {Name}";
    }

}
