using System.Text.Json.Serialization;
using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Units.Abstracts;
using ConsoleRpg.Services.DataHelpers;

namespace ConsoleRpg.Models.Items;

public abstract class Item : IItem
{
    // Item is a class that holds item information.
    public int ItemId { get; set; }
    [JsonIgnore]

    public abstract string ItemType { get; set; }
    public virtual List<Unit> Units { get; set; }
    public virtual List<UnitItem> UnitItems { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Item() { }

    public Item(string name)
    {
        Name = StringHelper.ToItemNameFormat(name);
        Description = StringHelper.ToItemNameFormat(Name);
    }

    public Item(string name, string desc)
    {
        Name = StringHelper.ToItemNameFormat(name);
        Description = StringHelper.ToItemNameFormat(desc);
    }

    public override string ToString()
    {
        return StringHelper.ToItemIdFormat(Name);
    }

}
