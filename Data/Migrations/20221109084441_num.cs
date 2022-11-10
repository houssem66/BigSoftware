using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class num : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumFax",
                table: "Fournisseurs");

            migrationBuilder.DropColumn(
                name: "Numbureau",
                table: "Fournisseurs");

            migrationBuilder.AddColumn<string>(
                name: "NumMobile",
                table: "Fournisseurs",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneBureau",
                table: "Fournisseurs",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumMobile",
                table: "Fournisseurs");

            migrationBuilder.DropColumn(
                name: "PhoneBureau",
                table: "Fournisseurs");

            migrationBuilder.AddColumn<int>(
                name: "NumFax",
                table: "Fournisseurs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Numbureau",
                table: "Fournisseurs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
