using ConsoleRpg.DataTypes;
using ConsoleRpg.Models.Abilities;
using ConsoleRpg.Models.Dungeons;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Models.Rooms;
using ConsoleRpg.Models.Units.Abstracts;
using ConsoleRpg.Services;

namespace ConsoleRpg.Data;

public class SeedHandler
{
    private GameContext _db;
    private RoomFactory _roomFactory;
    private UnitManager _unitManager;
    private List<Room> _rooms = new();
    private FlyAbility fly = new();
    private HealAbility heal = new();
    private StealAbility steal = new();
    private TauntAbility taunt = new();
    public SeedHandler(GameContext context, RoomFactory roomFactory, UnitManager unitManager)
    {
        _db = context;
        _roomFactory = roomFactory;
        _unitManager = unitManager;
    }

    public void SeedFromJson()
    {
        _unitManager.ImportUnits();
        if (!_db.Dungeons.Any())
        {
            Dungeon dungeon = new Dungeon();
            dungeon.Name = "Intro Dungeon";
            dungeon.Description = "The first dungeon in the game";
            Room entrance = _roomFactory.CreateRoom("intro.entrance");
            Room jail = _roomFactory.CreateRoom("intro.jail");
            Room kitchen = _roomFactory.CreateRoom("intro.kitchen");
            Room hallway = _roomFactory.CreateRoom("intro.hallway");
            Room library = _roomFactory.CreateRoom("intro.entrance");
            Room dwelling = _roomFactory.CreateRoom("intro.dwelling");
            Room dwelling2 = _roomFactory.CreateRoom("intro.dwelling2");
            entrance.AddAdjacentRoom(jail, Direction.West);
            entrance.AddAdjacentRoom(kitchen, Direction.East);
            entrance.AddAdjacentRoom(hallway, Direction.North);
            hallway.AddAdjacentRoom(dwelling2, Direction.West);
            hallway.AddAdjacentRoom(library, Direction.East);
            hallway.AddAdjacentRoom(dwelling, Direction.North);
            _rooms.AddRange<Room>(entrance, jail, kitchen, hallway, library, dwelling, dwelling2);

            dungeon.StartingRoom = entrance;

            _db.Dungeons.Add(dungeon);

            foreach (Room room in _rooms)
            {
                _db.Rooms.Add(room);
            }
        }

        if (!_db.Abilities.Any())
        {
            _db.Abilities.Add(fly);
            _db.Abilities.Add(heal);
            _db.Abilities.Add(steal);
            _db.Abilities.Add(taunt);
        }

        if (!_db.Units.Any())
        {
            foreach (Character unit in _unitManager.Characters.Units)
            {
                AddToDb(unit);
            }
            foreach (Monster unit in _unitManager.Monsters.Units)
            {
                AddToDb(unit);
            }
        }
        _db.SaveChanges();
    }

    private void AddToDb(Unit unit)
    {
        Random numberGenerator = new Random();
        int random = numberGenerator.Next(0,7);
        Room room = _rooms[random];
        unit.CurrentRoom = room;

        _db.Units.Add(unit);
        _db.Stats.Add(unit.Stat);
        _db.Inventories.Add(unit.Inventory);
        foreach (Item item in unit.Inventory.Items)
        {
            _db.Items.Add(item);
        }
        switch (unit.UnitType)
        {
            case "EnemyGhost":
                unit.Abilities.Add(fly);
                break;
            case "Cleric" or "EnemyCleric":
                unit.Abilities.Add(heal);
                break;
            case "EnemyGoblin" or "Knight":
                unit.Abilities.Add(taunt);
                break;
            case "Rogue":
                unit.Abilities.Add(steal);
                break;

        }
    }
}
