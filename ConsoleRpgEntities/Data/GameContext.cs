﻿using ConsoleRpgEntities.Models.Abilities;
using ConsoleRpgEntities.Models.Combat;
using ConsoleRpgEntities.Models.Dungeons;
using ConsoleRpgEntities.Models.Items;
using ConsoleRpgEntities.Models.Items.ConsumableItems;
using ConsoleRpgEntities.Models.Items.EquippableItems.ArmorItems;
using ConsoleRpgEntities.Models.Items.EquippableItems.WeaponItems;
using ConsoleRpgEntities.Models.Rooms;
using ConsoleRpgEntities.Models.Units.Abstracts;
using ConsoleRpgEntities.Models.Units.Characters;
using ConsoleRpgEntities.Models.Units.Monsters;
using Microsoft.EntityFrameworkCore;

namespace ConsoleRpgEntities.Data;

public class GameContext : DbContext
{
    // DbSet properties for each entity type that will be mapped to the database
    public DbSet<Dungeon> Dungeons { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Stat> Stats { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Ability> Abilities { get; set; }
    public DbSet<UnitItem> UnitItems { get; set; }
    public GameContext() { }
    public GameContext(DbContextOptions<GameContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Configures the GameContext to be able to use the UnitType property as a discriminator for the Unit entity
        builder.Entity<Unit>()
            .HasDiscriminator(unit => unit.UnitType)
            .HasValue<Cleric>(nameof(Cleric))
            .HasValue<Fighter>(nameof(Fighter))
            .HasValue<Knight>(nameof(Knight))
            .HasValue<Rogue>(nameof(Rogue))
            .HasValue<Wizard>(nameof(Wizard))

            .HasValue<EnemyArcher>(nameof(EnemyArcher))
            .HasValue<EnemyCleric>(nameof(EnemyCleric))
            .HasValue<EnemyGhost>(nameof(EnemyGhost))
            .HasValue<EnemyGoblin>(nameof(EnemyGoblin))
            .HasValue<EnemyMage>(nameof(EnemyMage));

        // Configures the GameContext to be able to use the ItemType property as a discriminator for the Item entity
        builder.Entity<Item>()
            .HasDiscriminator(item => item.ItemType)
            .HasValue<GenericItem>(nameof(GenericItem))

            .HasValue<ItemBook>(nameof(ItemBook))
            .HasValue<ItemLockpick>(nameof(ItemLockpick))
            .HasValue<ItemPotion>(nameof(ItemPotion))

            .HasValue<MagicWeaponItem>(nameof(MagicWeaponItem))
            .HasValue<PhysicalWeaponItem>(nameof(PhysicalWeaponItem))

            .HasValue<HeadArmorItem>(nameof(HeadArmorItem))
            .HasValue<ChestArmorItem>(nameof(ChestArmorItem))
            .HasValue<LegArmorItem>(nameof(LegArmorItem))
            .HasValue<FeetArmorItem>(nameof(FeetArmorItem));

        // Configures the GameContext to be able to use the AbilityType property as a discriminator for the Ability entity
        builder.Entity<Ability>()
            .HasDiscriminator(ability => ability.AbilityType)
            .HasValue<FlyAbility>(nameof(FlyAbility))
            .HasValue<HealAbility>(nameof(HealAbility))
            .HasValue<StealAbility>(nameof(StealAbility))
            .HasValue<TauntAbility>(nameof(TauntAbility));

        // Creates a many-to-many relationship between Unit and Item and maps it to the UnitItems table
        builder.Entity<Unit>()
        .HasMany(unit => unit.Abilities)
        .WithMany(ability => ability.Units)
        .UsingEntity(join => join.ToTable("UnitAbility"));
    }
}