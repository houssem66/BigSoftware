using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ht : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrixTotale",
                table: "StockProduits",
                newName: "PrixTotaleTTc");

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "StockProduits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "StockProduits");

            migrationBuilder.RenameColumn(
                name: "PrixTotaleTTc",
                table: "StockProduits",
                newName: "PrixTotale");
        }
    }
}
