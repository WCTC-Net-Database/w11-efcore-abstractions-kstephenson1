using ConsoleRpg.DataTypes;

namespace ConsoleRpg.Models.Interfaces.ItemBehaviors;

public interface IEquippableWeapon : IEquippableItem
{
    public WeaponType WeaponType { get; set; }
    public int Might { get; set; }
    public int Hit { get; set; }
    public int Crit { get; set; }
    public int Range { get; set; }
}
