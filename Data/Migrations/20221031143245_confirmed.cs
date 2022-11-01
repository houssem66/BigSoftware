using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class confirmed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "BonLivraisonClients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "BonLivraisonClients");
        }
    }
}
