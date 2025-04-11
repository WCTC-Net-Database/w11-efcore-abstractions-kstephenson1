using ConsoleRPG.DataTypes;

namespace ConsoleRPG.Models.Items.WeaponItems;

public class WeaponItem : EquippableItem
{
    // WeaponItem is a class that holds weapon item information
    public override string ItemType { get; set; } = "WeaponItem";
    public WeaponItem()
    {
        
    }
    public WeaponItem(string id, string name, WeaponType weaponType, WeaponRank requiredRank, int maxDurability, int might, int hit, int crit, int range, int weight, int expModifier) : base(id, name, weaponType, requiredRank, maxDurability, might, hit, crit, range, weight, expModifier)
    {
        
    }

    public override string ToString()
    {
        return $"[[{Durability}/{MaxDurability}]] {Name}";
    }

}
