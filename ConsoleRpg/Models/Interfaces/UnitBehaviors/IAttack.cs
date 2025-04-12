using ConsoleRpg.Models.Commands.Invokers;
using ConsoleRpg.Models.Commands.ItemCommands;
using ConsoleRpg.Models.Commands.UnitCommands;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;

namespace ConsoleRpg.Models.Interfaces.UnitBehaviors;

public interface IAttack
{
    // Interface tha allows units to attack.
    CommandInvoker Invoker { set; get; }
    AttackCommand AttackCommand { set; get; }
    EquipCommand EquipCommand { set; get; }

    void Attack(IUnit target);
    void Equip(IEquippableItem item);
}
