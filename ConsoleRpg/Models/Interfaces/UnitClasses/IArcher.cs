using ConsoleRPG.Models.Interfaces.UnitBehaviors;

namespace ConsoleRPG.Models.Interfaces.UnitClasses;

public interface IArcher : IShootable
{
    // An Archer unit that is able to shoot.
    public void Attack(IUnit target) => Shoot(target);
}
