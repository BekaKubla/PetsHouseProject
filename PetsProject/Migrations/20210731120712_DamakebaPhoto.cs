using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsProject.Migrations
{
    public partial class DamakebaPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DamakebaPhotoUrl",
                table: "Damakeba",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DamakebaPhotoUrl",
                table: "Damakeba");
        }
    }
}
