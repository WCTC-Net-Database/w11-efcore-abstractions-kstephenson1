﻿namespace ConsoleRPG.Models.Interfaces.FileIO;

public interface IItemIO : IFileIO
{
    new public List<TItem> Read<TItem>(string dir);
    new public void Write<TItem>(List<TItem> items, string dir);
}
