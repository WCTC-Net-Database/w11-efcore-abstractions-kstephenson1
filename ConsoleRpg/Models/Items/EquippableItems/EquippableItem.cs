using System.Text.Json.Serialization;
using ConsoleRpg.DataTypes;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;
using ConsoleRpg.Services.DataHelpers;

namespace ConsoleRpg.Models.Items.EquippableItems;

public abstract class EquippableItem : Item, IEquippableItem
{
    // Item is a class that holds item information.



    [JsonConverter(typeof(JsonStringEnumConverter<Rank>))]
    public Rank RequiredRank { get; set; }
    public int MaxDurability { get; set; }
    public int Durability { get; set; }
    public int Weight { get; set; }
    public int ExpModifier { get; set; }

    protected EquippableItem()
    {
        
    }

    public EquippableItem(string name, Rank requiredRank, int maxDurability, int weight, int expModifier) : base(name)
    {
        MaxDurability = maxDurability;
        Name = name;
        RequiredRank = requiredRank;
        Weight = weight;
        Durability = maxDurability;
        ExpModifier = expModifier;
    }

    public override string ToString()
    {
        return StringHelper.ToItemIdFormat(Name);
    }

    public void Equip()
    {
        bool wasEquipped = Inventory.TryEquipItem(this);
        if (wasEquipped)
        {
            Console.WriteLine($"{Inventory.Unit!.Name} equipped {Name}");
        }
        else
        {
            Console.WriteLine($"{Inventory.Unit!.Name} already has {Name} equipped!");
        }
    }

    public void TakeDurabilityDamage(int durabilityDamage)
    {
        throw new NotImplementedException();
    }

    public void BreakItem()
    {
        throw new NotImplementedException();
    }
}
