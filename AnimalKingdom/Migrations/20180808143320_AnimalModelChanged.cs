using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalKingdom.Migrations
{
    public partial class AnimalModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExtinct",
                table: "Animals",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExtinct",
                table: "Animals");
        }
    }
}
