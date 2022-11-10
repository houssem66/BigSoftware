using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class civility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Civility",
                table: "Fournisseurs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Civility",
                table: "Fournisseurs");
        }
    }
}
