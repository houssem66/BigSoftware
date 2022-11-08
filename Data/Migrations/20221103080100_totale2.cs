using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class totale2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixTotaleTTc2",
                table: "BonDeRéceptionFournisseurs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleTTc2",
                table: "BonDeRéceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
