using System.Text.Json.Serialization;
using ConsoleRpg.DataTypes;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;
using ConsoleRpg.Models.Items.EquippableItems;

namespace ConsoleRpg.Models.Items.WeaponItems;

public abstract class WeaponItem : EquippableItem, IEquippableWeapon
{
    // WeaponItem is a class that holds weapon item information
    public override string ItemType { get; set; } = "WeaponItem";
    [JsonConverter(typeof(JsonStringEnumConverter<WeaponType>))]
    public WeaponType WeaponType { get; set; }
    public int Might { get; set; }
    public int Hit { get; set; }
    public int Crit { get; set; }
    public int Range { get; set; }

    public WeaponItem()
    {
        
    }
    public WeaponItem(string name, WeaponType weaponType, Rank requiredRank, int maxDurability, int might, int hit, int crit, int range, int weight, int expModifier) : base(name, requiredRank, maxDurability, weight, expModifier)
    {
        WeaponType = weaponType;
        Might = might;
        Hit = hit;
        Crit = crit;
        Range = range;
    }

    public override string ToString()
    {
        return $"[[{Durability}/{MaxDurability}]] {Name}";
    }

}
