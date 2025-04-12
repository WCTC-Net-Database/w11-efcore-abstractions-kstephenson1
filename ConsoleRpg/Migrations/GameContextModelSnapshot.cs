﻿// <auto-generated />
using ConsoleRpg.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleRpg.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AbilityUnit", b =>
                {
                    b.Property<int>("AbilitiesAbilityId")
                        .HasColumnType("int");

                    b.Property<int>("UnitsUnitId")
                        .HasColumnType("int");

                    b.HasKey("AbilitiesAbilityId", "UnitsUnitId");

                    b.HasIndex("UnitsUnitId");

                    b.ToTable("UnitAbility", (string)null);
                });

            modelBuilder.Entity("ConsoleRpg.Models.Abilities.Ability", b =>
                {
                    b.Property<int>("AbilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AbilityId"));

                    b.Property<string>("AbilityType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AbilityId");

                    b.ToTable("Abilities");

                    b.HasDiscriminator<string>("AbilityType").HasValue("Ability");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ConsoleRpg.Models.Combat.Stat", b =>
                {
                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("Constitution")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<int>("Luck")
                        .HasColumnType("int");

                    b.Property<int>("Magic")
                        .HasColumnType("int");

                    b.Property<int>("MaxHitPoints")
                        .HasColumnType("int");

                    b.Property<int>("Movement")
                        .HasColumnType("int");

                    b.Property<int>("Resistance")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("UnitId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Dungeons.Dungeon", b =>
                {
                    b.Property<int>("DungeonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DungeonId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartingRoomRoomId")
                        .HasColumnType("int");

                    b.HasKey("DungeonId");

                    b.HasIndex("StartingRoomRoomId");

                    b.ToTable("Dungeons");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<string>("ItemType")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("ItemType").HasValue("Item");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ConsoleRpg.Models.Rooms.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Units.Abstracts.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitId"));

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurrentRoomRoomId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("UnitId");

                    b.HasIndex("CurrentRoomRoomId");

                    b.HasIndex("ItemId");

                    b.ToTable("Units");

                    b.HasDiscriminator<string>("UnitType").HasValue("Unit");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("UnitItem", b =>
                {
                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("UnitId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("UnitItems");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Abilities.FlyAbility", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Abilities.Ability");

                    b.HasDiscriminator().HasValue("FlyAbility");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Abilities.HealAbility", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Abilities.Ability");

                    b.HasDiscriminator().HasValue("HealAbility");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Abilities.StealAbility", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Abilities.Ability");

                    b.HasDiscriminator().HasValue("StealAbility");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Abilities.TauntAbility", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Abilities.Ability");

                    b.HasDiscriminator().HasValue("TauntAbility");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.ConsumableItems.ItemBook", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Items.Item");

                    b.Property<int>("MaxUses")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("UsesLeft")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("ItemBook");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.ConsumableItems.ItemLockpick", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Items.Item");

                    b.Property<int>("MaxUses")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("UsesLeft")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("ItemLockpick");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.ConsumableItems.ItemPotion", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Items.Item");

                    b.Property<int>("MaxUses")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("UsesLeft")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("ItemPotion");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.EquippableItems.ArmorItems.ChestArmorItem", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Items.Item");

                    b.Property<int>("ArmorType")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Durability")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("ExpModifier")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("MaxDurability")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("RequiredRank")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Resistance")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.ToTable("Items", t =>
                        {
                            t.Property("ArmorType")
                                .HasColumnName("ChestArmorItem_ArmorType");
                        });

                    b.HasDiscriminator().HasValue("ChestArmorItem");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.EquippableItems.ArmorItems.FeetArmorItem", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Items.Item");

                    b.Property<int>("ArmorType")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Durability")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("ExpModifier")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("MaxDurability")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("RequiredRank")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Resistance")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.ToTable("Items", t =>
                        {
                            t.Property("ArmorType")
                                .HasColumnName("FeetArmorItem_ArmorType");
                        });

                    b.HasDiscriminator().HasValue("FeetArmorItem");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.EquippableItems.ArmorItems.HeadArmorItem", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Items.Item");

                    b.Property<int>("ArmorType")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Durability")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("ExpModifier")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("MaxDurability")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("RequiredRank")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Resistance")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.ToTable("Items", t =>
                        {
                            t.Property("ArmorType")
                                .HasColumnName("HeadArmorItem_ArmorType");
                        });

                    b.HasDiscriminator().HasValue("HeadArmorItem");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.EquippableItems.ArmorItems.LegArmorItem", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Items.Item");

                    b.Property<int>("ArmorType")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Durability")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("ExpModifier")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("MaxDurability")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("RequiredRank")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Resistance")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("LegArmorItem");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.EquippableItems.WeaponItems.MagicWeaponItem", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Items.Item");

                    b.Property<int>("Crit")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Durability")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("ExpModifier")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Hit")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("MaxDurability")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Might")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Range")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("RequiredRank")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("WeaponType")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("MagicWeaponItem");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.EquippableItems.WeaponItems.PhysicalWeaponItem", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Items.Item");

                    b.Property<int>("Crit")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Durability")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("ExpModifier")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Hit")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("MaxDurability")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Might")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Range")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("RequiredRank")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("WeaponType")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("PhysicalWeaponItem");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.GenericItem", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Items.Item");

                    b.HasDiscriminator().HasValue("GenericItem");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Units.Characters.Cleric", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Units.Abstracts.Unit");

                    b.HasDiscriminator().HasValue("Cleric");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Units.Characters.Fighter", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Units.Abstracts.Unit");

                    b.HasDiscriminator().HasValue("Fighter");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Units.Characters.Knight", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Units.Abstracts.Unit");

                    b.HasDiscriminator().HasValue("Knight");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Units.Characters.Rogue", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Units.Abstracts.Unit");

                    b.HasDiscriminator().HasValue("Rogue");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Units.Characters.Wizard", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Units.Abstracts.Unit");

                    b.HasDiscriminator().HasValue("Wizard");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Units.Monsters.EnemyArcher", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Units.Abstracts.Unit");

                    b.HasDiscriminator().HasValue("EnemyArcher");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Units.Monsters.EnemyCleric", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Units.Abstracts.Unit");

                    b.HasDiscriminator().HasValue("EnemyCleric");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Units.Monsters.EnemyGhost", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Units.Abstracts.Unit");

                    b.HasDiscriminator().HasValue("EnemyGhost");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Units.Monsters.EnemyGoblin", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Units.Abstracts.Unit");

                    b.HasDiscriminator().HasValue("EnemyGoblin");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Units.Monsters.EnemyMage", b =>
                {
                    b.HasBaseType("ConsoleRpg.Models.Units.Abstracts.Unit");

                    b.HasDiscriminator().HasValue("EnemyMage");
                });

            modelBuilder.Entity("AbilityUnit", b =>
                {
                    b.HasOne("ConsoleRpg.Models.Abilities.Ability", null)
                        .WithMany()
                        .HasForeignKey("AbilitiesAbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleRpg.Models.Units.Abstracts.Unit", null)
                        .WithMany()
                        .HasForeignKey("UnitsUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleRpg.Models.Combat.Stat", b =>
                {
                    b.HasOne("ConsoleRpg.Models.Units.Abstracts.Unit", "Unit")
                        .WithOne("Stat")
                        .HasForeignKey("ConsoleRpg.Models.Combat.Stat", "UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Dungeons.Dungeon", b =>
                {
                    b.HasOne("ConsoleRpg.Models.Rooms.Room", "StartingRoom")
                        .WithMany()
                        .HasForeignKey("StartingRoomRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StartingRoom");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Units.Abstracts.Unit", b =>
                {
                    b.HasOne("ConsoleRpg.Models.Rooms.Room", "CurrentRoom")
                        .WithMany("Units")
                        .HasForeignKey("CurrentRoomRoomId");

                    b.HasOne("ConsoleRpg.Models.Items.Item", null)
                        .WithMany("Units")
                        .HasForeignKey("ItemId");

                    b.Navigation("CurrentRoom");
                });

            modelBuilder.Entity("UnitItem", b =>
                {
                    b.HasOne("ConsoleRpg.Models.Items.Item", "Item")
                        .WithMany("UnitItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleRpg.Models.Units.Abstracts.Unit", "Unit")
                        .WithMany("UnitItems")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Items.Item", b =>
                {
                    b.Navigation("UnitItems");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Rooms.Room", b =>
                {
                    b.Navigation("Units");
                });

            modelBuilder.Entity("ConsoleRpg.Models.Units.Abstracts.Unit", b =>
                {
                    b.Navigation("Stat")
                        .IsRequired();

                    b.Navigation("UnitItems");
                });
#pragma warning restore 612, 618
        }
    }
}
