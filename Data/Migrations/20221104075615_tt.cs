using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class tt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "BonCommandeClients");

            migrationBuilder.DropColumn(
                name: "PrixTotaleTTc",
                table: "BonCommandeClients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "BonCommandeClients",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleTTc",
                table: "BonCommandeClients",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
