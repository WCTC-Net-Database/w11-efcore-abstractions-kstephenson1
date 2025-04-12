namespace ConsoleRpg.Models.Interfaces.FileIO;

public interface ICharacterIO : IFileIO
{
    new List<TUnit> Read<TUnit>(string dir);
    new void Write<TUnit>(List<TUnit> unit, string dir);
}
