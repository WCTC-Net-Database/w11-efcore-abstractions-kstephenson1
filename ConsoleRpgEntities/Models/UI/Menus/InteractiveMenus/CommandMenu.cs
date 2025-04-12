using ConsoleRpgEntities.Data;
using ConsoleRpgEntities.Models.Commands.ItemCommands;
using ConsoleRpgEntities.Models.Commands.UnitCommands;
using ConsoleRpgEntities.Models.Units.Abstracts;
using ConsoleRpgEntities.Models.Interfaces;
using ConsoleRpgEntities.Models.Interfaces.Commands;
using ConsoleRpgEntities.Models.Interfaces.InventoryBehaviors;
using ConsoleRpgEntities.Models.Interfaces.UnitBehaviors;

namespace ConsoleRpgEntities.Models.UI.Menus.InteractiveMenus;

public class CommandMenu : InteractiveSelectionMenu<ICommand>
{

    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.

    private readonly GameContext _db;

    public CommandMenu(GameContext context)
    {
        _db = context;
    }

    public override void Display(string errorMessage)
    {
        throw new ArgumentException("CommandMenu(unit, prompt) requires a unit.");
    }

    public ICommand Display(IUnit unit, string prompt, string exitMessage)
    {
        ICommand selection = default!;
        bool exit = false;
        while (exit != true)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            Update(unit, exitMessage);
            BuildTable(exitMessage);
            Show();
            ConsoleKey key = ReturnValidKey();
            selection = DoKeyActionReturnUnit(key, out exit);
        }
        return selection;
    }

    public override void Update(string exitMessage)
    {
        throw new ArgumentException("Update(unit) requires a unit.");
    }

    public void Update(IUnit unit, string exitMessage)
    {
        _menuItems = new();

        AddMenuItem("Move", "Moves the unit.", new MoveCommand(null!));

        if (unit is IHaveInventory)
        {
            if (unit.UnitItems!.Count != 0)
                AddMenuItem("Items", "Uses an item in this unit's inventory.", new UseItemCommand(null!, null!));
            else
                AddMenuItem("[dim]Items[/]", "[dim]Uses an item in this unit's inventory.[/]", new UseItemCommand(null!, null!));
        }

        if (unit is IAttack && InventoryHelper.GetEquippedWeapon((Unit)unit) != null)
            AddMenuItem("Attack", "Attacks a target unit.", new AttackCommand(null!, null!));


        if (unit is ICastable)
            AddMenuItem("Cast", "Casts a spell.", new CastCommand(null!, "null"));

        AddMenuItem(exitMessage, "", null!);
    }
}

