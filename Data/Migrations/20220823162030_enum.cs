using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class @enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gouvernorats",
                table: "Fournisseurs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gouvernorats",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gouvernorats",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gouvernorats",
                table: "Fournisseurs");

            migrationBuilder.DropColumn(
                name: "Gouvernorats",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Gouvernorats",
                table: "AspNetUsers");
        }
    }
}
