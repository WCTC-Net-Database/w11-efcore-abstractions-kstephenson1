﻿using ConsoleRpgEntities.Models.Units.Abstracts;
using ConsoleRpgEntities.Services.DataHelpers;
using ConsoleRpgEntities.Models.Interfaces;

namespace ConsoleRpgEntities.Models.Items;

public abstract class Item : IItem
{
    // Item is an abstract class that represents an item in the game. It has a name, description, and a list of units
    // to establish a relationship between the item and the unit.
    public int ItemId { get; set; }
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
