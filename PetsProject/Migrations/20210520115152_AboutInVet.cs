using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsProject.Migrations
{
    public partial class AboutInVet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MoitivationMessage",
                table: "GetVetRegistraiton",
                newName: "CompanyName");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "GetVetRegistraiton",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "GetVetRegistraiton");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "GetVetRegistraiton",
                newName: "MoitivationMessage");
        }
    }
}
