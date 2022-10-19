using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ttc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prix",
                table: "FactureFournisseurs",
                newName: "PrixTotaleTTc");

            migrationBuilder.RenameColumn(
                name: "Prix",
                table: "FactureClients",
                newName: "PrixTotaleTTc");

            migrationBuilder.RenameColumn(
                name: "Prix",
                table: "Devis",
                newName: "PrixTotaleTTc");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsReceptionFournisseurs",
                newName: "MontantTTc");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsLivraisonClients",
                newName: "MontantTTc");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsFactureFournisseurs",
                newName: "MontantTTc");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsFactureClients",
                newName: "MontantTTc");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsDevis",
                newName: "MontantTTc");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsCommandeFournisseurs",
                newName: "MontantTTc");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsCommandeClients",
                newName: "MontantTTc");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsBonSorties",
                newName: "MontantTTc");

            migrationBuilder.RenameColumn(
                name: "Prix",
                table: "BonSorties",
                newName: "PrixTotaleTTc");

            migrationBuilder.RenameColumn(
                name: "Prix",
                table: "BonLivraisonClients",
                newName: "PrixTotaleTTc");

            migrationBuilder.RenameColumn(
                name: "Prix",
                table: "BonDeRéceptionFournisseurs",
                newName: "PrixTotaleTTc");

            migrationBuilder.RenameColumn(
                name: "Prix",
                table: "BonDeCommandeFournisseurs",
                newName: "PrixTotaleTTc");

            migrationBuilder.RenameColumn(
                name: "Prix",
                table: "BonCommandeClients",
                newName: "PrixTotaleTTc");

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "FactureFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "FactureClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "Devis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantHt",
                table: "DetailsReceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantHt",
                table: "DetailsLivraisonClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantHt",
                table: "DetailsFactureFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantHt",
                table: "DetailsFactureClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantHt",
                table: "DetailsDevis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantHt",
                table: "DetailsCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantHt",
                table: "DetailsCommandeClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantHt",
                table: "DetailsBonSorties",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "BonSorties",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "BonLivraisonClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "BonDeRéceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "BonDeCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotaleHt",
                table: "BonCommandeClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "FactureFournisseurs");

            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "FactureClients");

            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "Devis");

            migrationBuilder.DropColumn(
                name: "MontantHt",
                table: "DetailsReceptionFournisseurs");

            migrationBuilder.DropColumn(
                name: "MontantHt",
                table: "DetailsLivraisonClients");

            migrationBuilder.DropColumn(
                name: "MontantHt",
                table: "DetailsFactureFournisseurs");

            migrationBuilder.DropColumn(
                name: "MontantHt",
                table: "DetailsFactureClients");

            migrationBuilder.DropColumn(
                name: "MontantHt",
                table: "DetailsDevis");

            migrationBuilder.DropColumn(
                name: "MontantHt",
                table: "DetailsCommandeFournisseurs");

            migrationBuilder.DropColumn(
                name: "MontantHt",
                table: "DetailsCommandeClients");

            migrationBuilder.DropColumn(
                name: "MontantHt",
                table: "DetailsBonSorties");

            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "BonSorties");

            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "BonLivraisonClients");

            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "BonDeRéceptionFournisseurs");

            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "BonDeCommandeFournisseurs");

            migrationBuilder.DropColumn(
                name: "PrixTotaleHt",
                table: "BonCommandeClients");

            migrationBuilder.RenameColumn(
                name: "PrixTotaleTTc",
                table: "FactureFournisseurs",
                newName: "Prix");

            migrationBuilder.RenameColumn(
                name: "PrixTotaleTTc",
                table: "FactureClients",
                newName: "Prix");

            migrationBuilder.RenameColumn(
                name: "PrixTotaleTTc",
                table: "Devis",
                newName: "Prix");

            migrationBuilder.RenameColumn(
                name: "MontantTTc",
                table: "DetailsReceptionFournisseurs",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "MontantTTc",
                table: "DetailsLivraisonClients",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "MontantTTc",
                table: "DetailsFactureFournisseurs",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "MontantTTc",
                table: "DetailsFactureClients",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "MontantTTc",
                table: "DetailsDevis",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "MontantTTc",
                table: "DetailsCommandeFournisseurs",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "MontantTTc",
                table: "DetailsCommandeClients",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "MontantTTc",
                table: "DetailsBonSorties",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "PrixTotaleTTc",
                table: "BonSorties",
                newName: "Prix");

            migrationBuilder.RenameColumn(
                name: "PrixTotaleTTc",
                table: "BonLivraisonClients",
                newName: "Prix");

            migrationBuilder.RenameColumn(
                name: "PrixTotaleTTc",
                table: "BonDeRéceptionFournisseurs",
                newName: "Prix");

            migrationBuilder.RenameColumn(
                name: "PrixTotaleTTc",
                table: "BonDeCommandeFournisseurs",
                newName: "Prix");

            migrationBuilder.RenameColumn(
                name: "PrixTotaleTTc",
                table: "BonCommandeClients",
                newName: "Prix");
        }
    }
}
