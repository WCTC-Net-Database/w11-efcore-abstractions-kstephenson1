using ConsoleRPG.Models.Combat;
using ConsoleRPG.Models.Interfaces;
using ConsoleRPG.Models.Units.Abstracts;
using ConsoleRPG.Services;
using ConsoleRPG.Data;

namespace ConsoleRPG.Models.UI.Menus.InteractiveMenus;

public class UnitSelectionMenu : InteractiveSelectionMenu<IUnit>
{

    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.

    private readonly GameContext _db;

    public UnitSelectionMenu(GameContext context)
    {
        _db = context;
    }

    public override IUnit Display(string prompt, string exitMessage   )
    {
        IUnit selection = default!;
        bool exit = false;
        while (exit != true)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            Update(exitMessage);
            BuildTable(exitMessage);
            Show();
            ConsoleKey key = ReturnValidKey();
            selection = DoKeyActionReturnUnit(key, out exit);
        }
        return selection;
    }

    public override void Update(string exitMessage)
    {
        _menuItems = new();

        List<Unit> units = _db.Units.ToList();
        List<Stat> stats = _db.Stats.ToList();
        List<Unit> characters = new();
        List<Unit> monsters = new();
        foreach(Unit unit in units)
        {
            if (unit.UnitType.Contains("Enemy"))
                {
                monsters.Add(unit);
            }
            else
            {
                characters.Add(unit);
            }
        }

        // Adds all the characters to the unit list using green letters.
        foreach (IUnit unit in characters)
        {
            Stat stat = stats.FirstOrDefault(s => s.UnitId == unit.UnitId);

            // Strikethrough and dim the unit info if the unit is not alive.
            if (stat.HitPoints <= 0)
            {
                AddMenuItem($"[green][dim][strikethrough]{unit.Name} Level {unit.Level} {unit.Class}[/][/][/]", $" {unit.GetHealthBar()}", unit);
            }
            else
            {
                AddMenuItem($"[green][bold]{unit.Name}[/][/] Level {unit.Level} {unit.Class}", $" {unit.GetHealthBar()}", unit);
            }
        }
        // Adds all the monsters to the unit list using red letters.
        foreach (IUnit unit in monsters)
        {
            Stat stat = stats.FirstOrDefault(s => s.UnitId == unit.UnitId);

            if (stat.HitPoints <= 0)
            {
                // Strikethrough and dim the unit info if the unit is not alive.
                AddMenuItem($"[red][dim][strikethrough]{unit.Name} Level {unit.Level} {unit.Class}[/][/][/]", $" {unit.GetHealthBar()}", unit);
            }
            else
            {
                AddMenuItem($"[red][bold]{unit.Name}[/][/] Level {unit.Level} {unit.Class}", $" {unit.GetHealthBar()}", unit);
            }
        }
        AddMenuItem(exitMessage, $"", null!);
    }
}

