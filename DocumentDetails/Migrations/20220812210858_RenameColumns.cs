using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentDetails.Migrations
{
    public partial class RenameColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dokumentumok_dokumentumok_ParentId",
                table: "dokumentumok");

            migrationBuilder.DropForeignKey(
                name: "FK_naplo_dokumentumok_DocumentId",
                table: "naplo");

            migrationBuilder.DropForeignKey(
                name: "FK_naplo_esemeny_EventId",
                table: "naplo");

            migrationBuilder.RenameColumn(
                name: "HappenedAt",
                table: "naplo",
                newName: "happened_at");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "naplo",
                newName: "esemeny_id");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "naplo",
                newName: "dokumentum_id");

            migrationBuilder.RenameIndex(
                name: "IX_naplo_EventId",
                table: "naplo",
                newName: "IX_naplo_esemeny_id");

            migrationBuilder.RenameIndex(
                name: "IX_naplo_DocumentId",
                table: "naplo",
                newName: "IX_naplo_dokumentum_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "esemeny",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "esemeny",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "dokumentumok",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "dokumentumok",
                newName: "source");

            migrationBuilder.RenameColumn(
                name: "Extension",
                table: "dokumentumok",
                newName: "extension");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "dokumentumok",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "dokumentumok",
                newName: "main_id");

            migrationBuilder.RenameIndex(
                name: "IX_dokumentumok_ParentId",
                table: "dokumentumok",
                newName: "IX_dokumentumok_main_id");

            migrationBuilder.AddForeignKey(
                name: "FK_dokumentumok_dokumentumok_main_id",
                table: "dokumentumok",
                column: "main_id",
                principalTable: "dokumentumok",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_naplo_dokumentumok_dokumentum_id",
                table: "naplo",
                column: "dokumentum_id",
                principalTable: "dokumentumok",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_naplo_esemeny_esemeny_id",
                table: "naplo",
                column: "esemeny_id",
                principalTable: "esemeny",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dokumentumok_dokumentumok_main_id",
                table: "dokumentumok");

            migrationBuilder.DropForeignKey(
                name: "FK_naplo_dokumentumok_dokumentum_id",
                table: "naplo");

            migrationBuilder.DropForeignKey(
                name: "FK_naplo_esemeny_esemeny_id",
                table: "naplo");

            migrationBuilder.RenameColumn(
                name: "happened_at",
                table: "naplo",
                newName: "HappenedAt");

            migrationBuilder.RenameColumn(
                name: "esemeny_id",
                table: "naplo",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "dokumentum_id",
                table: "naplo",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_naplo_esemeny_id",
                table: "naplo",
                newName: "IX_naplo_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_naplo_dokumentum_id",
                table: "naplo",
                newName: "IX_naplo_DocumentId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "esemeny",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "esemeny",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "dokumentumok",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "source",
                table: "dokumentumok",
                newName: "Source");

            migrationBuilder.RenameColumn(
                name: "extension",
                table: "dokumentumok",
                newName: "Extension");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "dokumentumok",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "main_id",
                table: "dokumentumok",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_dokumentumok_main_id",
                table: "dokumentumok",
                newName: "IX_dokumentumok_ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_dokumentumok_dokumentumok_ParentId",
                table: "dokumentumok",
                column: "ParentId",
                principalTable: "dokumentumok",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_naplo_dokumentumok_DocumentId",
                table: "naplo",
                column: "DocumentId",
                principalTable: "dokumentumok",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_naplo_esemeny_EventId",
                table: "naplo",
                column: "EventId",
                principalTable: "esemeny",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
