using System.Reflection;
using ConsoleRpg.Services;

namespace ConsoleRpg.Models.UI.Menus.InteractiveMenus;

public class UnitClassMenu : InteractiveSelectionMenu<Type>
{

    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.

    public UnitClassMenu()
    {

    }

    public override Type Display(string prompt, string exitMessage)
    {
        Type selection = default!;
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

        string characterNamespace = "w10_assignment_ksteph.Models.Units.Characters";
        IEnumerable<Type> unitTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.IsClass && t.Namespace == characterNamespace
                select t;

        foreach (Type unitType in unitTypes)
        {
            AddMenuItem($"{unitType.Name}", $"", unitType);
        }

        AddMenuItem(exitMessage, $"", null!);
    }
}

