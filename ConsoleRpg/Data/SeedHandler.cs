using ConsoleRpg.DataTypes;
using ConsoleRpg.Models.Abilities;
using ConsoleRpg.Models.Combat;
using ConsoleRpg.Models.Dungeons;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Models.Items.ConsumableItems;
using ConsoleRpg.Models.Items.EquippableItems.ArmorItems;
using ConsoleRpg.Models.Items.EquippableItems.WeaponItems;
using ConsoleRpg.Models.Rooms;
using ConsoleRpg.Models.Units.Abstracts;
using ConsoleRpg.Models.Units.Characters;
using ConsoleRpg.Models.Units.Monsters;
using ConsoleRpg.Services;
using Spectre.Console;

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

    private ItemPotion potion;
    private ItemBook book;
    private ItemLockpick lockpick;

    private PhysicalWeaponItem sword;
    private PhysicalWeaponItem axe;
    private PhysicalWeaponItem dagger;
    private PhysicalWeaponItem bow;
    private PhysicalWeaponItem staff;
    private PhysicalWeaponItem mace;

    private MagicWeaponItem fire;
    private MagicWeaponItem ice;
    private MagicWeaponItem lightning;
    private MagicWeaponItem decay;
    private MagicWeaponItem smite;

    private HeadArmorItem hood;
    private ChestArmorItem shirt;
    private ChestArmorItem cloak;
    private LegArmorItem pants;
    private FeetArmorItem shoes;

    private HeadArmorItem cap;
    private ChestArmorItem tunic;
    private LegArmorItem studdedPants;
    private FeetArmorItem boots;

    private HeadArmorItem helm;
    private ChestArmorItem plate;
    private LegArmorItem greaves;
    private FeetArmorItem sabatons;



    public SeedHandler(GameContext context, RoomFactory roomFactory)
    {
        _db = context;
        _roomFactory = roomFactory;
    }

    public void SeedDatabase()
    {
        if (!_db.Items.Any())
        {
            DisplaySeedProgressBar();
            GenerateItems();
        }

        if (!_db.Dungeons.Any())
            GenerateDungeons();

        if (!_db.Abilities.Any())
            GenerateAbilities();

        if (!_db.Units.Any())
            GenerateCharacters();

        

        _db.SaveChanges();
    }

    private void GenerateItems()
    {
        potion = new();
        lockpick = new();
        book = new();

        //Physical Weapons
        sword = new()
        {
            Name = "Sword",
            Description = "A basic sword.",
            WeaponType = WeaponType.Sword,
            RequiredRank = Rank.E,
            MaxDurability = 45,
            Durability = 45,
            Might = 5,
            Hit = 80,
            Crit = 0,
            Range = 1,
            Weight = 4,
            ExpModifier = 1,
        };

        axe = new()
        {
            Name = "Axe",
            Description = "A basic axe",
            WeaponType = WeaponType.Axe,
            RequiredRank = Rank.E,
            MaxDurability = 45,
            Durability = 45,
            Might = 7,
            Hit = 70,
            Crit = 0,
            Range = 1,
            Weight = 6,
            ExpModifier = 1,
        };

        dagger = new()
        {
            Name = "Dagger",
            Description = "A basic dagger",
            WeaponType = WeaponType.Sword,
            RequiredRank = Rank.E,
            MaxDurability = 45,
            Durability = 45,
            Might = 4,
            Hit = 100,
            Crit = 10,
            Range = 1,
            Weight = 2,
            ExpModifier = 1,
        };

        bow = new()
        {
            Name = "Bow",
            Description = "A basic bow",
            WeaponType = WeaponType.Bow,
            RequiredRank = Rank.E,
            MaxDurability = 45,
            Durability = 45,
            Might = 7,
            Hit = 75,
            Crit = 0,
            Range = 2,
            Weight = 3,
            ExpModifier = 1,
        };

        staff = new()
        {
            Name = "Staff",
            Description = "A basic staff",
            WeaponType = WeaponType.Lance,
            RequiredRank = Rank.E,
            MaxDurability = 45,
            Durability = 45,
            Might = 6,
            Hit = 85,
            Crit = 0,
            Range = 1,
            Weight = 3,
            ExpModifier = 1,
        };

        mace = new()
        {
            Name = "Mace",
            Description = "A basic mace",
            WeaponType = WeaponType.Axe,
            RequiredRank = Rank.E,
            MaxDurability = 45,
            Durability = 45,
            Might = 8,
            Hit = 70,
            Crit = 0,
            Range = 1,
            Weight = 5,
            ExpModifier = 1,
        };

        // Magic Weapons

        fire = new()
        {
            Name = "Fire",
            Description = "A basic fire spell",
            WeaponType = WeaponType.Elemental,
            RequiredRank = Rank.E,
            MaxDurability = 45,
            Durability = 45,
            Might = 6,
            Hit = 80,
            Crit = 0,
            Range = 2,
            Weight = 4,
            ExpModifier = 1,
        };

        ice = new()
        {
            Name = "Ice",
            Description = "A basic ice spell",
            WeaponType = WeaponType.Elemental,
            RequiredRank = Rank.E,
            MaxDurability = 45,
            Durability = 45,
            Might = 6,
            Hit = 80,
            Crit = 0,
            Range = 2,
            Weight = 4,
            ExpModifier = 1,
        };

        lightning = new()
        {
            Name = "Lightning",
            Description = "A basic lightning spell",
            WeaponType = WeaponType.Elemental,
            RequiredRank = Rank.E,
            MaxDurability = 45,
            Durability = 45,
            Might = 6,
            Hit = 80,
            Crit = 0,
            Range = 2,
            Weight = 4,
            ExpModifier = 1,
        };

        decay = new()
        {
            Name = "Decay",
            Description = "A basic decay spell",
            WeaponType = WeaponType.Dark,
            RequiredRank = Rank.E,
            MaxDurability = 45,
            Durability = 45,
            Might = 7,
            Hit = 70,
            Crit = 0,
            Range = 2,
            Weight = 4,
            ExpModifier = 1,
        };

        smite = new()
        {
            Name = "Smite",
            Description = "A basic smite spell",
            WeaponType = WeaponType.Light,
            RequiredRank = Rank.E,
            MaxDurability = 45,
            Durability = 45,
            Might = 5,
            Hit = 90,
            Crit = 10,
            Range = 2,
            Weight = 4,
            ExpModifier = 1,
        };

        // Armor Items
        hood = new()
        {
            Name = "Hood",
            Description = "A basic hood",
            ArmorType = ArmorType.Head,
            RequiredRank = Rank.E,
            MaxDurability = 30,
            Durability = 30,
            Defense = 0,
            Resistance = 2,
            Weight = 1,
            ExpModifier = 1,
        };

        shirt = new()
        {
            Name = "Shirt",
            Description = "A basic shirt",
            ArmorType = ArmorType.Chest,
            RequiredRank = Rank.E,
            MaxDurability = 30,
            Durability = 30,
            Defense = 0,
            Resistance = 2,
            Weight = 1,
            ExpModifier = 1,
        };

        cloak = new()
        {
            Name = "Cloak",
            Description = "A basic cloak",
            ArmorType = ArmorType.Chest,
            RequiredRank = Rank.E,
            MaxDurability = 30,
            Durability = 30,
            Defense = 0,
            Resistance = 2,
            Weight = 1,
            ExpModifier = 1,
        };

        pants = new()
        {
            Name = "Pants",
            Description = "A basic pants",
            ArmorType = ArmorType.Legs,
            RequiredRank = Rank.E,
            MaxDurability = 30,
            Durability = 30,
            Defense = 0,
            Resistance = 2,
            Weight = 1,
            ExpModifier = 1,
        };

        shoes = new()
        {
            Name = "Shoes",
            Description = "A basic shoes",
            ArmorType = ArmorType.Feet,
            RequiredRank = Rank.E,
            MaxDurability = 30,
            Durability = 30,
            Defense = 0,
            Resistance = 2,
            Weight = 1,
            ExpModifier = 1,
        };

        cap = new()
        {
            Name = "Leather Cap",
            Description = "A basic leather cap",
            ArmorType = ArmorType.Head,
            RequiredRank = Rank.E,
            MaxDurability = 30,
            Durability = 30,
            Defense = 1,
            Resistance = 1,
            Weight = 3,
            ExpModifier = 1,
        };

        tunic = new()
        {
            Name = "Leather Tunic",
            Description = "A basic leather tunic",
            ArmorType = ArmorType.Chest,
            RequiredRank = Rank.E,
            MaxDurability = 30,
            Durability = 30,
            Defense = 1,
            Resistance = 1,
            Weight = 3,
            ExpModifier = 1,
        };

        studdedPants = new()
        {
            Name = "Studded Pants",
            Description = "A basic studded pants",
            ArmorType = ArmorType.Legs,
            RequiredRank = Rank.E,
            MaxDurability = 30,
            Durability = 30,
            Defense = 1,
            Resistance = 1,
            Weight = 3,
            ExpModifier = 1,
        };

        boots = new()
        {
            Name = "Leather Boots",
            Description = "A basic leather boots",
            ArmorType = ArmorType.Feet,
            RequiredRank = Rank.E,
            MaxDurability = 30,
            Durability = 30,
            Defense = 1,
            Resistance = 1,
            Weight = 3,
            ExpModifier = 1,
        };

        helm = new()
        {
            Name = "Helm",
            Description = "A basic plate helm",
            ArmorType = ArmorType.Head,
            RequiredRank = Rank.E,
            MaxDurability = 30,
            Durability = 30,
            Defense = 2,
            Resistance = -1,
            Weight = 3,
            ExpModifier = 1,
        };

        plate = new()
        {
            Name = "Plate Armor",
            Description = "A basic plate armor",
            ArmorType = ArmorType.Chest,
            RequiredRank = Rank.E,
            MaxDurability = 30,
            Durability = 30,
            Defense = 2,
            Resistance = -1,
            Weight = 3,
            ExpModifier = 1,
        };

        greaves = new()
        {
            Name = "Greaves",
            Description = "A basic plate greaves",
            ArmorType = ArmorType.Legs,
            RequiredRank = Rank.E,
            MaxDurability = 30,
            Durability = 30,
            Defense = 2,
            Resistance = -1,
            Weight = 3,
            ExpModifier = 1,
        };

        sabatons = new()
        {
            Name = "Sabatons",
            Description = "A basic plate sabatons",
            ArmorType = ArmorType.Feet,
            RequiredRank = Rank.E,
            MaxDurability = 30,
            Durability = 30,
            Defense = 2,
            Resistance = -1,
            Weight = 3,
            ExpModifier = 1,
        };

        _db.Items.AddRange(potion, lockpick, book,
            sword, axe, dagger, bow, staff, mace,
            fire, ice, lightning, decay, smite,
            hood, shirt, cloak, pants, shoes,
            cap, tunic, studdedPants, boots,
            helm, plate, greaves, sabatons);

        _db.SaveChanges();
    }
    private void GenerateCharacters()
    {
        List<Item> items = _db.Items.ToList();

        Unit unit = new Fighter();
        unit.Name = "John, Brave";
        unit.Class = "Fighter";
        unit.Level = 1;
        AddItem(unit, sword, EquipmentSlot.Weapon);
        AddItem(unit, tunic, EquipmentSlot.Chest);
        AddItem(unit, potion);
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
        foreach (UnitItem unitItem in unit.UnitItems)
            _db.UnitItems.Add(unitItem);


        unit = new Wizard();
        unit.Name = "Jane";
        unit.Class = "Wizard";
        unit.Level = 2;
        AddItem(unit, decay, EquipmentSlot.Weapon);
        AddItem(unit, hood, EquipmentSlot.Head);
        AddItem(unit, staff, EquipmentSlot.Weapon);
        AddItem(unit, potion, EquipmentSlot.Weapon);
        AddItem(unit, book, EquipmentSlot.Weapon);


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
        foreach (UnitItem unitItem in unit.UnitItems)
            _db.UnitItems.Add(unitItem);

        unit = new Rogue();
        unit.Name = "Bob, Sneaky";
        unit.Class = "Rogue";
        unit.Level = 3;
        AddItem(unit, lockpick);
        AddItem(unit, dagger, EquipmentSlot.Weapon);
        AddItem(unit, pants, EquipmentSlot.Legs);
        AddItem(unit, shoes, EquipmentSlot.Feet);
        AddItem(unit, potion);
        unit.Abilities.Add(steal);
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
        foreach (UnitItem unitItem in unit.UnitItems)
            _db.UnitItems.Add(unitItem);

        unit = new Cleric();
        unit.Name = "Alice";
        unit.Class = "Cleric";
        unit.Level = 4;
        AddItem(unit, potion);
        AddItem(unit, plate, EquipmentSlot.Chest);
        AddItem(unit, greaves, EquipmentSlot.Legs);
        AddItem(unit, smite, EquipmentSlot.Weapon);
        AddItem(unit, mace);

        unit.Abilities.Add(heal);
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
        foreach (UnitItem unitItem in unit.UnitItems)
            _db.UnitItems.Add(unitItem);

        unit = new Knight();
        unit.Name = "Reginald III, Sir";
        unit.Class = "Knight";
        unit.Level = 5;
        AddItem(unit, potion);
        AddItem(unit, sword, EquipmentSlot.Weapon);
        AddItem(unit, helm, EquipmentSlot.Head);
        AddItem(unit, plate, EquipmentSlot.Chest);
        AddItem(unit, greaves, EquipmentSlot.Legs);
        AddItem(unit, sabatons, EquipmentSlot.Feet);
        unit.Abilities.Add(taunt);
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
        foreach (UnitItem unitItem in unit.UnitItems)
            _db.UnitItems.Add(unitItem);

        unit = new EnemyGhost();
        unit.Name = "Poltergeist";
        unit.Class = "Ghost";
        unit.Level = 1;
        AddItem(unit, axe, EquipmentSlot.Weapon);
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
        unit.Abilities.Add(fly);
        unit.CurrentRoom = GetRandomRoom();
        _db.Units.Add(unit);
        _db.Stats.Add(unit.Stat);
        foreach (UnitItem unitItem in unit.UnitItems)
            _db.UnitItems.Add(unitItem);

        unit = new EnemyGoblin();
        unit.Name = "Ruthless Treasure-Gather";
        unit.Class = "Goblin";
        unit.Level = 2;
        AddItem(unit, sword, EquipmentSlot.Weapon);
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
        foreach (UnitItem unitItem in unit.UnitItems)
            _db.UnitItems.Add(unitItem);

        unit = new EnemyArcher();
        unit.Name = "Sniper";
        unit.Class = "Archer";
        unit.Level = 3;
        AddItem(unit, bow, EquipmentSlot.Weapon);

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
        foreach (UnitItem unitItem in unit.UnitItems)
            _db.UnitItems.Add(unitItem);

        unit = new EnemyMage();
        unit.Name = "Studious Spellcaster";
        unit.Class = "Mage";
        unit.Level = 4;
 
        AddItem(unit, lightning, EquipmentSlot.Weapon);
        AddItem(unit, potion);
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
        foreach (UnitItem unitItem in unit.UnitItems)
            _db.UnitItems.Add(unitItem);

        unit = new EnemyCleric();
        unit.Name = "Doctor of the Fallen";
        unit.Class = "Cleric";
        unit.Level = 5;
        AddItem(unit, potion);
        AddItem(unit, mace);
        AddItem(unit, plate, EquipmentSlot.Chest);
        AddItem(unit, smite, EquipmentSlot.Weapon);
        unit.Abilities.Add(heal);
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
        foreach (UnitItem unitItem in unit.UnitItems)
            _db.UnitItems.Add(unitItem);
    }

    private void GenerateAbilities()
    {
        _db.Abilities.Add(fly);
        _db.Abilities.Add(heal);
        _db.Abilities.Add(steal);
        _db.Abilities.Add(taunt);
    }

    private void GenerateDungeons()
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

    private Room GetRandomRoom()
    {
        Random numberGenerator = new Random();
        int random = numberGenerator.Next(0, 7);
        return _rooms[random];
    }

    private void AddItem(Unit unit, Item item)
    {
        AddItem(unit, item, EquipmentSlot.None);
    }

    private void AddItem(Unit unit, Item item, EquipmentSlot slot)
    {
        if(unit.UnitItems == null)
            unit.UnitItems = new();
        unit.UnitItems.Add(new()
        {
            Item = item,
            ItemId = item.ItemId,
            Unit = unit,
            UnitId = unit.UnitId,
            Slot = slot
        });
    }

    async private void DisplaySeedProgressBar()
    {
        // Added a progress bar to simulate the progress of the seeding process.
        AnsiConsole.Progress()
        .AutoRefresh(true)
        .AutoClear(false)
        .HideCompleted(false)
        .Columns(new ProgressColumn[]
        {
            new TaskDescriptionColumn(),
            new ProgressBarColumn(),
            new PercentageColumn(),
            new RemainingTimeColumn(),
            new SpinnerColumn(),
            new DownloadedColumn(),
            new TransferSpeedColumn(),
        })
        .Start(ctx =>
        {
            double progress = 55;
            var taskTotal = ctx.AddTask("[white][[Seeding Database]][/]", true, 21716);
            var taskItems = ctx.AddTask("[white]Generating Items[/]", true, 8362);
            var taskRooms = ctx.AddTask("[white]Generating Rooms[/]", true, 1091);
            var taskDungeon = ctx.AddTask("[white]Generating Dungeon[/]", true, 850);
            var taskAbilities = ctx.AddTask("[white]Generating Abilties[/]", true, 159);
            var taskUnits = ctx.AddTask("[white]Generating Units[/]", true, 7643);
            var taskStats = ctx.AddTask("[white]Generating Stats[/]", true, 2410);
            var taskInventory = ctx.AddTask("[white]Generating Inventory[/]", true, 1201);

            while (!ctx.IsFinished)
            {
                Thread.Sleep(10);
                taskTotal.Increment(progress * 1.30);
                if (!taskItems.IsFinished)
                {
                    taskItems.Increment(progress);
                    taskRooms.Increment(progress / 2);
                    taskDungeon.Increment(progress / 4);
                }
                else if (!taskRooms.IsFinished)
                {
                    taskRooms.Increment(progress);
                    taskDungeon.Increment(progress / 2);
                    taskAbilities.Increment(progress / 4);
                }
                else if (!taskDungeon.IsFinished)
                {
                    taskDungeon.Increment(progress);
                    taskAbilities.Increment(progress/2);
                    taskUnits.Increment(progress/4);
                }
                else if (!taskAbilities.IsFinished)
                {
                    taskAbilities.Increment(progress);
                    taskUnits.Increment(progress/2);
                    taskStats.Increment(progress/4);
                }
                else if (!taskUnits.IsFinished)
                {
                    taskUnits.Increment(progress);
                    taskStats.Increment(progress/2);
                    taskInventory.Increment(progress/4);
                }
                else if (!taskStats.IsFinished)
                {
                    taskStats.Increment(progress);
                    taskInventory.Increment(progress/2);
                }
                else if (!taskInventory.IsFinished)
                {
                    taskInventory.Increment(progress);
                }
            }
        });
    }
}
