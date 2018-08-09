using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalKingdom.Migrations
{
    public partial class AnimalModelChangedBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExtinct",
                table: "Animals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExtinct",
                table: "Animals",
                nullable: false,
                defaultValue: false);
        }
    }
}
