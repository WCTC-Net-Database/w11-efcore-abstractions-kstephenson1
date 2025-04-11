using ConsoleRPG.Models.Commands.Invokers;
using ConsoleRPG.Models.Commands.ItemCommands;
using ConsoleRPG.Models.Commands.UnitCommands;
using ConsoleRPG.Models.Interfaces.ItemBehaviors;

namespace ConsoleRPG.Models.Interfaces.UnitBehaviors;

public interface IAttack
{
    // Interface tha allows units to attack.
    CommandInvoker Invoker { set; get; }
    AttackCommand AttackCommand { set; get; }
    EquipCommand EquipCommand { set; get; }

    void Attack(IUnit target);
    void Equip(IEquippableItem item);
}
