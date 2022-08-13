using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentDetails.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dokumentumok",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    extension = table.Column<int>(type: "int", nullable: false),
                    main_id = table.Column<int>(type: "int", nullable: true),
                    source = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dokumentumok", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "esemeny",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_esemeny", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "naplo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dokumentum_id = table.Column<int>(type: "int", nullable: false),
                    esemeny_id = table.Column<int>(type: "int", nullable: false),
                    happened_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_naplo", x => x.id);
                    table.ForeignKey(
                        name: "FK_naplo_dokumentumok_dokumentum_id",
                        column: x => x.dokumentum_id,
                        principalTable: "dokumentumok",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_naplo_esemeny_esemeny_id",
                        column: x => x.esemeny_id,
                        principalTable: "esemeny",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "dokumentumok",
                columns: new[] { "id", "extension", "main_id", "source", "title" },
                values: new object[,]
                {
                    { 1, 0, null, 0, "Szamlak_20200112153545" },
                    { 2, 0, 1, 1, "Szamla_20200112153545_1" },
                    { 3, 0, 1, 1, "Szamla_20200112153545_2" },
                    { 4, 0, 1, 1, "Szamla_20200112153545_3" },
                    { 5, 0, 1, 1, "Szamla_20200112153545_4" },
                    { 6, 0, 1, 1, "Szamla_20200112153545_5" },
                    { 7, 0, 1, 1, "Szamla_20200112153545_6" },
                    { 8, 0, 1, 1, "Szamla_20200112153545_7" },
                    { 9, 0, null, 2, "Szamlak_20200115132432" },
                    { 10, 0, null, 0, "Szamlak_20200116135412" },
                    { 11, 0, 10, 1, "Szamla_20200116135412_1" },
                    { 12, 0, 10, 1, "Szamla_20200116135412_2" },
                    { 13, 0, 10, 1, "Szamla_20200116135412_3" },
                    { 14, 0, null, 2, "Jovahagyas_TesztElek_EV" },
                    { 15, 1, null, 2, "Jovahagyott_tetellista" },
                    { 16, 0, null, 0, "Szallito_FuvarBt_20200214" },
                    { 17, 0, null, 0, "Szallito_FuvarBt_20200216" }
                });

            migrationBuilder.InsertData(
                table: "esemeny",
                columns: new[] { "id", "title" },
                values: new object[,]
                {
                    { 1, "Beérkezés" },
                    { 2, "Létrehozás" },
                    { 3, "Képjavítás" },
                    { 4, "Szeparálás" },
                    { 5, "OCR" },
                    { 6, "Adatkinyerés" },
                    { 7, "Áthelyezés feltöltésre" },
                    { 8, "Adatcsomag készítés" },
                    { 9, "Feltöltés" },
                    { 10, "Művelet befejezve" },
                    { 11, "Mappa művelet hiba" },
                    { 12, "Hiányos adatréteg" },
                    { 13, "Sikertelen feltöltés" },
                    { 14, "Áthelyezés sikertelen mappába" }
                });

            migrationBuilder.InsertData(
                table: "naplo",
                columns: new[] { "id", "dokumentum_id", "esemeny_id", "happened_at" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2020, 1, 12, 15, 35, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 4, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 10, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, 2, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 3, 2, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 4, 2, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 5, 2, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 6, 2, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 7, 2, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 8, 2, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 2, 3, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 2, 5, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 2, 6, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 2, 7, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 2, 8, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 2, 9, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 2, 10, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 3, 3, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 3, 5, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 3, 6, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 3, 7, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 3, 8, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 3, 9, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 3, 10, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 4, 3, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 4, 5, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 4, 6, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 4, 7, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 4, 8, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 4, 9, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 4, 10, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 5, 3, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 5, 5, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 5, 6, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 5, 7, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 5, 8, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 5, 9, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 5, 10, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 6, 3, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 6, 5, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 6, 6, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 6, 7, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "naplo",
                columns: new[] { "id", "dokumentum_id", "esemeny_id", "happened_at" },
                values: new object[,]
                {
                    { 43, 6, 8, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 6, 9, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 6, 10, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 7, 3, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 7, 5, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 7, 6, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 7, 12, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 7, 14, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 8, 3, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 8, 5, new DateTime(2020, 1, 12, 15, 39, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 8, 6, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 8, 12, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 8, 14, new DateTime(2020, 1, 12, 15, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 9, 1, new DateTime(2020, 1, 15, 13, 24, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 9, 3, new DateTime(2020, 1, 15, 13, 24, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 9, 5, new DateTime(2020, 1, 15, 13, 24, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 9, 6, new DateTime(2020, 1, 15, 13, 24, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 9, 7, new DateTime(2020, 1, 15, 13, 27, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 9, 8, new DateTime(2020, 1, 15, 13, 27, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 9, 9, new DateTime(2020, 1, 15, 13, 27, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 9, 13, new DateTime(2020, 1, 15, 13, 28, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 9, 14, new DateTime(2020, 1, 15, 13, 28, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 10, 1, new DateTime(2020, 1, 16, 13, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 10, 4, new DateTime(2020, 1, 16, 13, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 10, 10, new DateTime(2020, 1, 16, 13, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 11, 2, new DateTime(2020, 1, 16, 13, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 12, 2, new DateTime(2020, 1, 16, 13, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 13, 2, new DateTime(2020, 1, 16, 13, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 11, 3, new DateTime(2020, 1, 16, 13, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 11, 5, new DateTime(2020, 1, 16, 13, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 11, 6, new DateTime(2020, 1, 16, 13, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 11, 7, new DateTime(2020, 1, 16, 13, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 11, 8, new DateTime(2020, 1, 16, 13, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 11, 9, new DateTime(2020, 1, 16, 13, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 11, 10, new DateTime(2020, 1, 16, 13, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 12, 3, new DateTime(2020, 1, 16, 13, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 12, 5, new DateTime(2020, 1, 16, 13, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 12, 6, new DateTime(2020, 1, 16, 13, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 12, 7, new DateTime(2020, 1, 16, 13, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 12, 8, new DateTime(2020, 1, 16, 13, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 12, 9, new DateTime(2020, 1, 16, 13, 56, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 12, 10, new DateTime(2020, 1, 16, 13, 55, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "naplo",
                columns: new[] { "id", "dokumentum_id", "esemeny_id", "happened_at" },
                values: new object[,]
                {
                    { 85, 13, 3, new DateTime(2020, 1, 16, 13, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 13, 5, new DateTime(2020, 1, 16, 13, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 13, 6, new DateTime(2020, 1, 16, 13, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 13, 7, new DateTime(2020, 1, 16, 13, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 13, 8, new DateTime(2020, 1, 16, 13, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 13, 9, new DateTime(2020, 1, 16, 13, 56, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 13, 10, new DateTime(2020, 1, 16, 13, 56, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 14, 1, new DateTime(2020, 1, 16, 16, 25, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 14, 3, new DateTime(2020, 1, 16, 16, 25, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 14, 5, new DateTime(2020, 1, 16, 16, 25, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 14, 6, new DateTime(2020, 1, 16, 16, 25, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 14, 7, new DateTime(2020, 1, 16, 16, 25, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 14, 8, new DateTime(2020, 1, 16, 16, 25, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 14, 9, new DateTime(2020, 1, 16, 16, 25, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 14, 10, new DateTime(2020, 1, 16, 16, 26, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 15, 1, new DateTime(2020, 1, 16, 16, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 101, 15, 7, new DateTime(2020, 1, 16, 16, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 102, 15, 9, new DateTime(2020, 1, 16, 16, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 103, 15, 10, new DateTime(2020, 1, 16, 16, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 104, 16, 1, new DateTime(2020, 2, 14, 11, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 105, 16, 3, new DateTime(2020, 2, 14, 11, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 106, 16, 5, new DateTime(2020, 2, 14, 11, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 107, 16, 6, new DateTime(2020, 2, 14, 11, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 108, 16, 7, new DateTime(2020, 2, 14, 11, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 109, 16, 8, new DateTime(2020, 2, 14, 11, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 110, 16, 9, new DateTime(2020, 2, 14, 11, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 16, 10, new DateTime(2020, 2, 14, 11, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 112, 17, 1, new DateTime(2020, 2, 16, 14, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 113, 17, 3, new DateTime(2020, 2, 16, 14, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 114, 17, 5, new DateTime(2020, 2, 16, 14, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 115, 17, 6, new DateTime(2020, 2, 16, 14, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 116, 17, 7, new DateTime(2020, 2, 16, 14, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 117, 17, 8, new DateTime(2020, 2, 16, 14, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 118, 17, 9, new DateTime(2020, 2, 16, 14, 54, 0, 0, DateTimeKind.Unspecified) },
                    { 119, 17, 13, new DateTime(2020, 2, 16, 14, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 120, 17, 14, new DateTime(2020, 2, 16, 14, 55, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_naplo_dokumentum_id",
                table: "naplo",
                column: "dokumentum_id");

            migrationBuilder.CreateIndex(
                name: "IX_naplo_esemeny_id",
                table: "naplo",
                column: "esemeny_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "naplo");

            migrationBuilder.DropTable(
                name: "dokumentumok");

            migrationBuilder.DropTable(
                name: "esemeny");
        }
    }
}
