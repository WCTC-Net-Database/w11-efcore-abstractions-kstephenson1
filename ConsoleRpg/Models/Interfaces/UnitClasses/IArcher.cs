using ConsoleRpg.Models.Interfaces.UnitBehaviors;

namespace ConsoleRpg.Models.Interfaces.UnitClasses;

public interface IArcher : IShootable
{
    // An Archer unit that is able to shoot.
    public void Attack(IUnit target) => Shoot(target);
}
