using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsProject.Migrations
{
    public partial class PetUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "GetPetRegistration",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "GetPetRegistration");
        }
    }
}
