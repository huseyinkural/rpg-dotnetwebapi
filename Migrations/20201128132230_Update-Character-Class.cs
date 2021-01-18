using Microsoft.EntityFrameworkCore.Migrations;

namespace rpg_webapi.Migrations
{
    public partial class UpdateCharacterClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HitPoint",
                table: "Characters",
                newName: "HitPoints");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HitPoints",
                table: "Characters",
                newName: "HitPoint");
        }
    }
}
