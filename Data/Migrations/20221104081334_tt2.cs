using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class tt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "FactureFournisseurs");

            migrationBuilder.DropColumn(
                name: "PrixTotaleTTc",
                table: "FactureFournisseurs");

            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "FactureClients");

            migrationBuilder.DropColumn(
                name: "PrixTotaleTTc",
                table: "FactureClients");

            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "Devis");

            migrationBuilder.DropColumn(
                name: "PrixTotaleTTc",
                table: "Devis");

            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "BonSorties");

            migrationBuilder.DropColumn(
                name: "PrixTotaleTTc",
                table: "BonSorties");

            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "BonLivraisonClients");

            migrationBuilder.DropColumn(
                name: "PrixTotaleTTc",
                table: "BonLivraisonClients");

            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "BonDeRéceptionFournisseurs");

            migrationBuilder.DropColumn(
                name: "PrixTotaleTTc",
                table: "BonDeRéceptionFournisseurs");

            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "BonDeCommandeFournisseurs");

            migrationBuilder.DropColumn(
                name: "PrixTotaleTTc",
                table: "BonDeCommandeFournisseurs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "FactureFournisseurs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleTTc",
                table: "FactureFournisseurs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "FactureClients",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleTTc",
                table: "FactureClients",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "Devis",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleTTc",
                table: "Devis",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "BonSorties",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleTTc",
                table: "BonSorties",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "BonLivraisonClients",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleTTc",
                table: "BonLivraisonClients",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "BonDeRéceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleTTc",
                table: "BonDeRéceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "BonDeCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleTTc",
                table: "BonDeCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
