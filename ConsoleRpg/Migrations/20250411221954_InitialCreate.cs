using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleRpg.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    AbilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.AbilityId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Dungeons",
                columns: table => new
                {
                    DungeonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingRoomRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dungeons", x => x.DungeonId);
                    table.ForeignKey(
                        name: "FK_Dungeons_Rooms_StartingRoomRoomId",
                        column: x => x.StartingRoomRoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CurrentRoomRoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_Units_Rooms_CurrentRoomRoomId",
                        column: x => x.CurrentRoomRoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId");
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    MaxHitPoints = table.Column<int>(type: "int", nullable: false),
                    Movement = table.Column<int>(type: "int", nullable: false),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Magic = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Luck = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Resistance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_Stats_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitAbility",
                columns: table => new
                {
                    AbilitiesAbilityId = table.Column<int>(type: "int", nullable: false),
                    UnitsUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitAbility", x => new { x.AbilitiesAbilityId, x.UnitsUnitId });
                    table.ForeignKey(
                        name: "FK_UnitAbility_Abilities_AbilitiesAbilityId",
                        column: x => x.AbilitiesAbilityId,
                        principalTable: "Abilities",
                        principalColumn: "AbilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitAbility_Units_UnitsUnitId",
                        column: x => x.UnitsUnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    EquippedWeaponId = table.Column<int>(type: "int", nullable: true),
                    EquippedHeadArmorId = table.Column<int>(type: "int", nullable: true),
                    EquippedChestArmorId = table.Column<int>(type: "int", nullable: true),
                    EquippedLegArmorId = table.Column<int>(type: "int", nullable: true),
                    EquippedFeetArmorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventories_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxUses = table.Column<int>(type: "int", nullable: true),
                    UsesLeft = table.Column<int>(type: "int", nullable: true),
                    ArmorType = table.Column<int>(type: "int", nullable: true),
                    Defense = table.Column<int>(type: "int", nullable: true),
                    Resistance = table.Column<int>(type: "int", nullable: true),
                    RequiredRank = table.Column<int>(type: "int", nullable: true),
                    MaxDurability = table.Column<int>(type: "int", nullable: true),
                    Durability = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    ExpModifier = table.Column<int>(type: "int", nullable: true),
                    WeaponType = table.Column<int>(type: "int", nullable: true),
                    Might = table.Column<int>(type: "int", nullable: true),
                    Hit = table.Column<int>(type: "int", nullable: true),
                    Crit = table.Column<int>(type: "int", nullable: true),
                    Range = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dungeons_StartingRoomRoomId",
                table: "Dungeons",
                column: "StartingRoomRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_EquippedChestArmorId",
                table: "Inventories",
                column: "EquippedChestArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_EquippedFeetArmorId",
                table: "Inventories",
                column: "EquippedFeetArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_EquippedHeadArmorId",
                table: "Inventories",
                column: "EquippedHeadArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_EquippedLegArmorId",
                table: "Inventories",
                column: "EquippedLegArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_EquippedWeaponId",
                table: "Inventories",
                column: "EquippedWeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_UnitId",
                table: "Inventories",
                column: "UnitId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_InventoryId",
                table: "Items",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitAbility_UnitsUnitId",
                table: "UnitAbility",
                column: "UnitsUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_CurrentRoomRoomId",
                table: "Units",
                column: "CurrentRoomRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Items_EquippedChestArmorId",
                table: "Inventories",
                column: "EquippedChestArmorId",
                principalTable: "Items",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Items_EquippedFeetArmorId",
                table: "Inventories",
                column: "EquippedFeetArmorId",
                principalTable: "Items",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Items_EquippedHeadArmorId",
                table: "Inventories",
                column: "EquippedHeadArmorId",
                principalTable: "Items",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Items_EquippedLegArmorId",
                table: "Inventories",
                column: "EquippedLegArmorId",
                principalTable: "Items",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Items_EquippedWeaponId",
                table: "Inventories",
                column: "EquippedWeaponId",
                principalTable: "Items",
                principalColumn: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Rooms_CurrentRoomRoomId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Items_EquippedChestArmorId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Items_EquippedFeetArmorId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Items_EquippedHeadArmorId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Items_EquippedLegArmorId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Items_EquippedWeaponId",
                table: "Inventories");

            migrationBuilder.DropTable(
                name: "Dungeons");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "UnitAbility");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
