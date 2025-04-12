using ConsoleRpg.Data;
using ConsoleRpg.DataTypes;
using ConsoleRpg.Models.Abilities;
using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Models.Items.EquippableItems.ArmorItems;
using ConsoleRpg.Models.Items.WeaponItems;
using ConsoleRpg.Models.Rooms;
using ConsoleRpg.Models.Units.Abstracts;
using Spectre.Console;

namespace ConsoleRpg.Models.UI.Character;

public class CharacterUI
{
    private GameContext _db;
    // CharacterUI helps display character information in a nice little table.
    public CharacterUI(GameContext context)
    {
        _db = context;
    }

    public void DisplayCharacterInfo(IUnit unit) // Displays the character's info
    {
        List<Unit> unitList = [(Unit)unit];
        DisplayCharacterInfo(unitList);
    }

    public void DisplayCharacterInfo(List<Unit> units)
    {
        List<Stat> stats = _db.Stats.ToList();
        List<UnitItem> unitItems = _db.UnitItems.ToList();
        List<Room> rooms = _db.Rooms.ToList();
        List<Ability> abilities = _db.Abilities.ToList();

        foreach (Unit unit in units)
        {
            Stat stat = stats.Where(s => s.UnitId == unit.UnitId).FirstOrDefault();
            List<UnitItem> ui = unitItems.Where(ui => ui.Unit == unit).ToList();
            List<Item> items = new();
            foreach (UnitItem unitItem in ui)
            {
                Item item = _db.Items.Where(i => i.ItemId == unitItem.ItemId).FirstOrDefault();
                items.Add(item);
            }
            Room unitRoom;
            try
            {
                unitRoom = rooms.Where(r => r.RoomId == unit.CurrentRoom.RoomId).FirstOrDefault();
            }
            catch { unitRoom = null; }
            List<Ability> unitAbilities = abilities.Where(a => a.Units.Contains(unit)).ToList();
            DisplayCharacterInfo(unit, stat, items, unitRoom, unitAbilities);
        }
    }

    public void DisplayCharacterInfo(IUnit unit, Stat stat, List<Item> items, Room room, List<Ability> abilities) // Displays the character's info
    {
        // Builds a character table with 2 lines: Name, Level and Class.
        Grid charTable = new Grid().Width(30).AddColumn();
        charTable
            .AddRow(new Text(unit.Name).Centered())
                .AddRow(new Text($"Level {unit.Level} {unit.Class}").Centered());

        // Builds an hp table that contains the health of the character
        Grid hpTable = new Grid().Width(25).AddColumn();
        hpTable
            .AddRow(new Text($"Hit Points:").Centered())
                .AddRow(new Text($"{stat.HitPoints}/{stat.MaxHitPoints}").Centered());

        //Creates a table that just says "Inventory:" This may be redesigned later.
        Grid invHeader = new Grid().Width(30).AddColumns(3);
        invHeader
            .AddRow(
                new Text($" STR: {stat.Strength}").LeftJustified(),
                new Text($"MAG: {unit.Stat.Magic}").LeftJustified(),
                new Text($"CON: {unit.Stat.Constitution}").LeftJustified())
            .AddRow(
                new Text($" DEX: {stat.Dexterity}").LeftJustified(),
                new Text($"SPD: {unit.Stat.Speed}").LeftJustified(),
                new Text($"LCK: {unit.Stat.Luck}").LeftJustified())
            .AddRow(
                new Text($" DEF: {stat.Defense}").LeftJustified(),
                new Text($"RES: {unit.Stat.Resistance}").LeftJustified(),
                new Text($"MOV: {unit.Stat.Movement}").LeftJustified());


        // Creates an inventory table that lists all the items in the character's inventory.
        Grid invTable = new Grid();
        invTable.AddColumn();

        //Inventory inventory = _db.Inventories.FirstOrDefault(i => i.UnitId == unit.UnitId);
        //var items = from i in _db.Items
        //            where i.InventoryId == unit.Inventory.InventoryId
        //            select i;
        List<IEquippableItem> equippedInventory = new();

        IEquippableWeapon? weapon = unit.GetEquippedWeapon();
        if (weapon != null)
        {
            equippedInventory.Add(weapon);
        }

        foreach (ArmorType armorType in Enum.GetValues(typeof(ArmorType)))
        {
            IEquippableArmor? armor = unit.GetEquippedArmorInSlot(armorType);
            if (armor != null)
            {
                equippedInventory.Add(armor);
            }
        }

        if (equippedInventory.Any())
        {
            invTable.AddRow("Equipped Items: ");

            foreach (IEquippableItem item in equippedInventory)
            {
                invTable.AddRow($"{item.ToString()}");
            }
        }
        else
        {
            invTable.AddRow("Equipped Items: ---");
        }

            invTable.AddRow("\nInventory: ");
        if (items.Count() != 0)
        {
            foreach (IItem item in items!)
            {
                invTable.AddRow(" - " + item.ToString());
            }
        }
        else
        {
            invTable.AddRow("(No Items)");
        }

        Grid roomTable = new Grid();
        roomTable.AddColumn();
        roomTable.AddRow("Current Room: " + (unit.CurrentRoom == null ? "null" : unit.CurrentRoom.Name));

        Grid abilityTable = new Grid();
        abilityTable.AddColumn();
        abilityTable.AddRow("Abilities: ");

        if (abilities.Any())
        {
            foreach(var ability in abilities)
            {
                abilityTable.AddRow(" - " + ability.Name);
            }
        }
        abilityTable.AddRow("");

        // Creates a display table that contains all the other tables to create a nice little display.
        Table displayTable = new Table();
        displayTable
            .AddColumn(new TableColumn(charTable))
            .AddColumn(new TableColumn(hpTable))
            .AddRow(roomTable, abilityTable)
            .AddRow(invHeader, invTable);

        // Displays the table to the user.
        AnsiConsole.Write(displayTable);
    }
}
