using ConsoleRpg.DataTypes;

namespace ConsoleRpg.Models.Interfaces.ItemBehaviors;

public interface IEquippableArmor : IEquippableItem
{
    public abstract ArmorType ArmorType { get; set; }
    public int Defense { get; set; }
    public int Resistance { get; set; }
}
