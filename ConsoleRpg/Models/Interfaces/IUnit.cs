using ConsoleRPG.Models.Abilities;
using ConsoleRPG.Models.Combat;
using ConsoleRPG.Models.Commands.UnitCommands;
using ConsoleRPG.Models.Interfaces.InventoryBehaviors;
using ConsoleRPG.Models.Interfaces.UnitBehaviors;
using ConsoleRPG.Models.Rooms;

namespace ConsoleRPG.Models.Interfaces;

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
    public List<Ability> Abilities { get; set; }

    void Move();
    string GetHealthBar();
}
