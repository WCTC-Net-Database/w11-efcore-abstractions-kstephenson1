﻿namespace ConsoleRPG.Models.Interfaces.ItemBehaviors;

public interface IConsumableItem : IItem
{
    public int MaxUses { get; set; }
    public int UsesLeft { get; set; }
    public void UseItem();
}
