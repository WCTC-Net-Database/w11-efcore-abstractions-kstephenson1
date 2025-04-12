using System.Reflection.Emit;
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
using Microsoft.EntityFrameworkCore;

namespace ConsoleRpg.Data;

public class GameContext : DbContext
{
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

        builder.Entity<Ability>()
            .HasDiscriminator(ability => ability.AbilityType)
            .HasValue<FlyAbility>(nameof(FlyAbility))
            .HasValue<HealAbility>(nameof(HealAbility))
            .HasValue<StealAbility>(nameof(StealAbility))
            .HasValue<TauntAbility>(nameof(TauntAbility));

        builder.Entity<Unit>()
        .HasMany(unit => unit.Abilities)
        .WithMany(ability => ability.Units)
        .UsingEntity(join => join.ToTable("UnitAbility"));

        //builder.Entity<Unit>()
        //.HasMany(unit => unit.Items)
        //.WithMany(item => item.Units)
        //.UsingEntity(join => join.ToTable("UnitItems"));

        //builder.Entity<UnitItem>()
        //    .HasOne(ui => ui.Unit)
        //    .WithMany(u => u.UnitItems)
        //    .HasForeignKey(ui => ui.UnitId)
        //    .HasConstraintName("FK_UnitItems_UnitId");

        //builder.Entity<UnitItem>()
        //    .HasOne(ui => ui.Item)
        //    .WithMany(i => i.UnitItems)
        //    .HasForeignKey(ui => ui.ItemId)
        //    .HasConstraintName("FK_UnitItems_ItemId");
    }
}