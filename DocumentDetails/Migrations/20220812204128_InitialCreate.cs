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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Source = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dokumentumok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dokumentumok_dokumentumok_ParentId",
                        column: x => x.ParentId,
                        principalTable: "dokumentumok",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "esemeny",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_esemeny", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "naplo",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    HappenedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_naplo_dokumentumok_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "dokumentumok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_naplo_esemeny_EventId",
                        column: x => x.EventId,
                        principalTable: "esemeny",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dokumentumok_ParentId",
                table: "dokumentumok",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_naplo_DocumentId",
                table: "naplo",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_naplo_EventId",
                table: "naplo",
                column: "EventId");
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
