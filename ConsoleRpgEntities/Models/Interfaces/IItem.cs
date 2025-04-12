using ConsoleRpgEntities.Models.Units.Abstracts;

namespace ConsoleRpgEntities.Models.Interfaces;

public interface IItem
{
    // Interface tha allows items to exist.
    public string Name { get; set; }
    public string Description { get; set; }
    List<Unit> Units { get; set; }
}
