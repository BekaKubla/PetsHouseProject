using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsProject.Migrations
{
    public partial class AddedPetPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PetPhotoUrl",
                table: "GetPetRegistration",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetPhotoUrl",
                table: "GetPetRegistration");
        }
    }
}
