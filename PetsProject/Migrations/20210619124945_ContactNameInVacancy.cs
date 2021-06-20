using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsProject.Migrations
{
    public partial class ContactNameInVacancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "GetVacancyRegistration");

            migrationBuilder.AddColumn<string>(
                name: "EmployerName",
                table: "GetVacancyRegistration",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployerName",
                table: "GetVacancyRegistration");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "GetVacancyRegistration",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
