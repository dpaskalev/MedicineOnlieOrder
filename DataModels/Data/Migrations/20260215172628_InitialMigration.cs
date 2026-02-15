using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataModels.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Loctaion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pharmacies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ExperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    MedicineTypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicines_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Medicines_MedicineTypes_MedicineTypeId",
                        column: x => x.MedicineTypeId,
                        principalTable: "MedicineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PharmaciesMedicines",
                columns: table => new
                {
                    PharmacyId = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmaciesMedicines", x => new { x.PharmacyId, x.MedicineId });
                    table.ForeignKey(
                        name: "FK_PharmaciesMedicines_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PharmaciesMedicines_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UsersMedicines",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersMedicines", x => new { x.UserId, x.MedicineId });
                    table.ForeignKey(
                        name: "FK_UsersMedicines_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UsersMedicines_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", 0, "b82418e6-51ac-404f-b4c4-49789fa34cad", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEFyJUYi/GFjLFTXnJFPCosU9wVpgbdmSXXT2cmWZIiyQUFVkFNuQrhCW1Vr6bd38iw==", null, false, "9dbc4e03-b998-41f2-8914-5f881e97f9b0", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "MedicineTypes",
                columns: new[] { "Id", "MedicineTypeName" },
                values: new object[,]
                {
                    { 1, "Pill" },
                    { 2, "Syringe" },
                    { 3, "Syrup" },
                    { 4, "Powder" },
                    { 5, "Liquid" }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Description", "ExperationDate", "ImageURL", "IsDeleted", "MedicineName", "MedicineTypeId", "Price", "UserId" },
                values: new object[,]
                {
                    { 1, "Caution", new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Local), null, false, "Med_1", 1, 100.0, "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd" },
                    { 2, "Caution", new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Local), null, false, "Med_2", 2, 200.0, "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd" },
                    { 3, "Caution", new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Local), null, false, "Med_3", 3, 100.0, "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd" }
                });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "Id", "IsDeleted", "Loctaion", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, false, "Suhata_Reka", "Pharmacy_1", "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd" },
                    { 2, false, "Suhata_Reka", "Pharmacy_2", "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd" },
                    { 3, false, "Suhata_Reka", "Pharmacy_3", "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineTypeId",
                table: "Medicines",
                column: "MedicineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_UserId",
                table: "Medicines",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_UserId",
                table: "Pharmacies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmaciesMedicines_MedicineId",
                table: "PharmaciesMedicines",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersMedicines_MedicineId",
                table: "UsersMedicines",
                column: "MedicineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmaciesMedicines");

            migrationBuilder.DropTable(
                name: "UsersMedicines");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "MedicineTypes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd");
        }
    }
}
