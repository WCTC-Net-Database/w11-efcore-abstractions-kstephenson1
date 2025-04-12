using ConsoleRpg.DataTypes;
using ConsoleRpg.Models.Abilities;
using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Dungeons;
using ConsoleRpg.Models.Interfaces;
using ConsoleRpg.Models.Interfaces.ItemBehaviors;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Models.Items.ConsumableItems;
using ConsoleRpg.Models.Items.EquippableItems.ArmorItems;
using ConsoleRpg.Models.Items.EquippableItems.WeaponItems;
using ConsoleRpg.Models.Items.WeaponItems;
using ConsoleRpg.Models.Rooms;
using ConsoleRpg.Models.Units.Abstracts;
using ConsoleRpg.Models.Units.Characters;
using ConsoleRpg.Models.Units.Monsters;
using ConsoleRpg.Services;

namespace ConsoleRpg.Data;

public class SeedHandler
{
    private GameContext _db;
    private RoomFactory _roomFactory;
    private List<Room> _rooms = new();

    private FlyAbility fly = new();
    private HealAbility heal = new();
    private StealAbility steal = new();
    private TauntAbility taunt = new();

    private ItemPotion potion = new();
    private ItemBook book = new();
    private ItemLockpick lockpick = new();

    private PhysicalWeaponItem sword = new("Sword", WeaponType.Sword, Rank.E, 10, 5, 5, 5, 1, 1, 1);
    private PhysicalWeaponItem axe = new("Axe", WeaponType.Axe, Rank.E, 10, 5, 5, 5, 1, 1, 1);
    private PhysicalWeaponItem dagger = new("Dagger", WeaponType.Sword, Rank.E, 10, 5, 5, 5, 1, 1, 1);
    private PhysicalWeaponItem bow = new("Bow", WeaponType.Bow, Rank.E, 10, 5, 5, 5, 1, 1, 1);
    private PhysicalWeaponItem staff = new("Staff", WeaponType.None, Rank.E, 10, 5, 5, 5, 1, 1, 1);
    private PhysicalWeaponItem mace = new("Mace", WeaponType.Axe, Rank.E, 10, 5, 5, 5, 1, 1, 1);

    private MagicWeaponItem fire = new("Fire", WeaponType.Elemental, Rank.E, 10, 5, 5, 5, 1, 1, 1);
    private MagicWeaponItem ice = new("Ice", WeaponType.Elemental, Rank.E, 10, 5, 5, 5, 1, 1, 1);
    private MagicWeaponItem lightning = new("Lightning", WeaponType.Elemental, Rank.E, 10, 5, 5, 5, 1, 1, 1);
    private MagicWeaponItem decay = new("Decay", WeaponType.Dark, Rank.E, 10, 5, 5, 5, 1, 1, 1);
    private MagicWeaponItem smite = new("Smite", WeaponType.Light, Rank.E, 10, 5, 5, 5, 1, 1, 1);

    private HeadArmorItem hood = new("Hood", ArmorType.Head, Rank.E, 30, 1, 5, 1, 0);
    private ChestArmorItem shirt = new("Shirt", ArmorType.Chest, Rank.E, 30, 1, 5, 1, 0);
    private ChestArmorItem cloak = new("Cloak", ArmorType.Chest, Rank.E, 30, 1, 5, 1, 0);
    private LegArmorItem pants = new("Shirt", ArmorType.Legs, Rank.E, 30, 1, 5, 1, 0);
    private FeetArmorItem shoes = new("Shoes", ArmorType.Feet, Rank.E, 30, 1, 5, 1, 0);

    private HeadArmorItem cap = new("Leather Cap", ArmorType.Head, Rank.E, 30, 2, 2, 3, 0);
    private ChestArmorItem tunic = new("Leather Tunic", ArmorType.Chest, Rank.E, 30, 2, 2, 3, 0);
    private LegArmorItem studdedPants = new("Studded Pants", ArmorType.Legs, Rank.E, 30, 2, 2, 3, 0);
    private FeetArmorItem boots = new("Leather Boots", ArmorType.Feet, Rank.E, 30, 2, 2, 3, 0);

    private HeadArmorItem helm = new("Helm", ArmorType.Head, Rank.E, 30, 5, 0, 5, 0);
    private ChestArmorItem plate = new("Plate Armor", ArmorType.Chest, Rank.E, 30, 5, 0, 5, 0);
    private LegArmorItem greaves = new("Greaves", ArmorType.Legs, Rank.E, 30, 5, 0, 5, 0);
    private FeetArmorItem sabatons = new("Sabatons", ArmorType.Feet, Rank.E, 30, 5, 0, 5, 0);



    public SeedHandler(GameContext context, RoomFactory roomFactory)
    {
        _db = context;
        _roomFactory = roomFactory;
    }

    public void SeedFromJson()
    {
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
            GenerateCharacters();
            //foreach (Character unit in _unitManager.Characters.Units)
            //{
            //    AddToDb(unit);
            //}
            //foreach (Monster unit in _unitManager.Monsters.Units)
            //{
            //    AddToDb(unit);
            //}
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
        foreach (Item item in unit.Items)
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

    public void GenerateCharacters()
    {
        Unit unit = new Fighter();
        unit.Name = "John, Brave";
        unit.Class = "Fighter";
        unit.Level = 1;
        unit.Items = new List<Item>
        {
            sword,
            tunic,
            potion
        };
        unit.Stat = new Stat
        {
            HitPoints = 28,
            MaxHitPoints = 28,
            Movement = 5,
            Constitution = 7,
            Strength = 10,
            Magic = 6,
            Dexterity = 7,
            Speed = 7,
            Luck = 8,
            Defense = 6,
            Resistance = 2
        };
        unit.CurrentRoom = GetRandomRoom();

        _db.Units.Add(unit);
        _db.Stats.Add(unit.Stat);
        _db.Items.AddRange(unit.Items);


        unit = new Wizard();
        unit.Name = "Jane";
        unit.Class = "Wizard";
        unit.Level = 2;
        unit.Items = new List<Item>
        {
            decay,
            shirt,
            staff,
            pants
        };
        unit.Stat = new Stat
        {
            HitPoints = 25,
            MaxHitPoints = 25,
            Movement = 5,
            Constitution = 4,
            Strength = 5,
            Magic = 11,
            Dexterity = 8,
            Speed = 7,
            Luck = 9,
            Defense = 3,
            Resistance = 5
        };
        unit.CurrentRoom = GetRandomRoom();
        _db.Units.Add(unit);
        _db.Stats.Add(unit.Stat);
        _db.Items.AddRange(unit.Items);


        unit = new Rogue();
        unit.Name = "Bob, Sneaky";
        unit.Class = "Rogue";
        unit.Level = 3;
        unit.Items = new List<Item>
        {
            dagger,
            lockpick,
            cloak            
        };
        unit.Stat = new Stat
        {
            HitPoints = 26,
            MaxHitPoints = 26,
            Movement = 6,
            Constitution = 5,
            Strength = 8,
            Magic = 11,
            Dexterity = 8,
            Speed = 12,
            Luck = 12,
            Defense = 9,
            Resistance = 8
        };
        unit.CurrentRoom = GetRandomRoom();
        _db.Units.Add(unit);
        _db.Stats.Add(unit.Stat);
        _db.Items.AddRange(unit.Items);


        unit = new Cleric();
        unit.Name = "Alice";
        unit.Class = "Cleric";
        unit.Level = 4;
        unit.Items = new List<Item>
        {
            smite,
            mace,
            plate,
            greaves,
            potion
        };
        unit.Stat = new Stat
        {
            HitPoints = 27,
            MaxHitPoints = 27,
            Movement = 5,
            Constitution = 4,
            Strength = 7,
            Magic = 9,
            Dexterity = 7,
            Speed = 7,
            Luck = 10,
            Defense = 6,
            Resistance = 7
        };
        unit.CurrentRoom = GetRandomRoom();
        _db.Units.Add(unit);
        _db.Stats.Add(unit.Stat);
        _db.Items.AddRange(unit.Items);


        unit = new Knight();
        unit.Name = "Reginald III, Sir";
        unit.Class = "Knight";
        unit.Level = 5;
        unit.Items = new List<Item>
        {
            sword,
            helm,
            plate,
            greaves,
            potion
        };
        unit.Stat = new Stat
        {
            HitPoints = 30,
            MaxHitPoints = 30,
            Movement = 4,
            Constitution = 10,
            Strength = 10,
            Magic = 9,
            Dexterity = 7,
            Speed = 5,
            Luck = 10,
            Defense = 13,
            Resistance = 5
        };
        unit.CurrentRoom = GetRandomRoom();
        _db.Units.Add(unit);
        _db.Stats.Add(unit.Stat);
        _db.Items.AddRange(unit.Items);


        unit = new EnemyGhost();
        unit.Name = "Poltergeist";
        unit.Class = "Ghost";
        unit.Level = 1;
        unit.Items = new List<Item>
        {
            axe
        };
        unit.Stat = new Stat
        {
            HitPoints = 25,
            MaxHitPoints = 25,
            Movement = 5,
            Constitution = 3,
            Strength = 8,
            Magic = 6,
            Dexterity = 7,
            Speed = 8,
            Luck = 8,
            Defense = 5,
            Resistance = 4
        };
        unit.CurrentRoom = GetRandomRoom();
        _db.Units.Add(unit);
        _db.Stats.Add(unit.Stat);
        _db.Items.AddRange(unit.Items);


        unit = new EnemyGoblin();
        unit.Name = "Ruthless Treasure-Gather";
        unit.Class = "Goblin";
        unit.Level = 2;
        unit.Items = new List<Item>
        {
            sword
        };
        unit.Stat = new Stat
        {
            HitPoints = 28,
            MaxHitPoints = 28,
            Movement = 5,
            Constitution = 5,
            Strength = 9,
            Magic = 7,
            Dexterity = 7,
            Speed = 8,
            Luck = 9,
            Defense = 6,
            Resistance = 2
        };
        unit.CurrentRoom = GetRandomRoom();
        _db.Units.Add(unit);
        _db.Stats.Add(unit.Stat);
        _db.Items.AddRange(unit.Items);


        unit = new EnemyArcher();
        unit.Name = "Sniper";
        unit.Class = "Archer";
        unit.Level = 3;
        unit.Items = new List<Item>
        {
            bow
        };
        unit.Stat = new Stat
        {
            HitPoints = 27,
            MaxHitPoints = 27,
            Movement = 5,
            Constitution = 6,
            Strength = 9,
            Magic = 7,
            Dexterity = 7,
            Speed = 8,
            Luck = 9,
            Defense = 6,
            Resistance = 2
        };
        unit.CurrentRoom = GetRandomRoom();
        _db.Units.Add(unit);
        _db.Stats.Add(unit.Stat);
        _db.Items.AddRange(unit.Items);


        unit = new EnemyMage();
        unit.Name = "Studious Spellcaster";
        unit.Class = "Mage";
        unit.Level = 4;
        unit.Items = new List<Item>
        {
            lightning, potion
        };
        unit.Stat = new Stat
        {
            HitPoints = 26,
            MaxHitPoints = 26,
            Movement = 5,
            Constitution = 4,
            Strength = 6,
            Magic = 10,
            Dexterity = 8,
            Speed = 9,
            Luck = 9,
            Defense = 6,
            Resistance = 7
        };
        unit.CurrentRoom = GetRandomRoom();
        _db.Units.Add(unit);
        _db.Stats.Add(unit.Stat);
        _db.Items.AddRange(unit.Items);


        unit = new EnemyCleric();
        unit.Name = "Doctor of the Fallen";
        unit.Class = "Cleric";
        unit.Level = 5;
        unit.Items = new List<Item>
        {
            smite, potion, mace
        };
        unit.Stat = new Stat
        {
            HitPoints = 29,
            MaxHitPoints = 29,
            Movement = 5,
            Constitution = 4,
            Strength = 8,
            Magic = 11,
            Dexterity = 8,
            Speed = 8,
            Luck = 8,
            Defense = 7,
            Resistance = 6
        };
        unit.CurrentRoom = GetRandomRoom();
        _db.Units.Add(unit);
        _db.Stats.Add(unit.Stat);
        _db.Items.AddRange(unit.Items);
        _db.SaveChanges();
    }

    private Room GetRandomRoom()
    {
        Random numberGenerator = new Random();
        int random = numberGenerator.Next(0, 7);
        return _rooms[random];
    }
}
