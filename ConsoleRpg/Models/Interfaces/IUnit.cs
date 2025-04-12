using ConsoleRpg.Models.Abilities;
using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Commands.AbilityCommands;
using ConsoleRpg.Models.Commands.UnitCommands;
using ConsoleRpg.Models.Interfaces.InventoryBehaviors;
using ConsoleRpg.Models.Interfaces.UnitBehaviors;
using ConsoleRpg.Models.Rooms;

namespace ConsoleRpg.Models.Interfaces;

public interface IUnit : ITargetable, IAttack, IHaveInventory, IUseItems
{
    // Interface tha allows units to exist.
    public int UnitId { get; set; }
    MoveCommand MoveCommand { set; get; }
    AbilityCommand AbilityCommand { set; get; }
    public string Name { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    Room? CurrentRoom { get; set; }
    public Stat Stat { get; set; }
    public List<Ability> Abilities { get; }

    void Move();
    string GetHealthBar();
}
