using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fiscale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormeJuridique",
                table: "Fournisseurs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Identifiant_fiscale",
                table: "Fournisseurs",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "FactureFournisseurs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotale",
                table: "DetailsReceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantité",
                table: "DetailsReceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotale",
                table: "DetailsLivraisonClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantité",
                table: "DetailsLivraisonClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotale",
                table: "DetailsFactureFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantité",
                table: "DetailsFactureFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotale",
                table: "DetailsFactureClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantité",
                table: "DetailsFactureClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotale",
                table: "DetailsDevis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantité",
                table: "DetailsDevis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotale",
                table: "DetailsCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantité",
                table: "DetailsCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotale",
                table: "DetailsCommandeClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantité",
                table: "DetailsCommandeClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixTotale",
                table: "DetailsBonSorties",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantité",
                table: "DetailsBonSorties",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BonDeRéceptionFournisseurs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BonDeCommandeFournisseurs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormeJuridique",
                table: "Fournisseurs");

            migrationBuilder.DropColumn(
                name: "Identifiant_fiscale",
                table: "Fournisseurs");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "FactureFournisseurs");

            migrationBuilder.DropColumn(
                name: "PrixTotale",
                table: "DetailsReceptionFournisseurs");

            migrationBuilder.DropColumn(
                name: "Quantité",
                table: "DetailsReceptionFournisseurs");

            migrationBuilder.DropColumn(
                name: "PrixTotale",
                table: "DetailsLivraisonClients");

            migrationBuilder.DropColumn(
                name: "Quantité",
                table: "DetailsLivraisonClients");

            migrationBuilder.DropColumn(
                name: "PrixTotale",
                table: "DetailsFactureFournisseurs");

            migrationBuilder.DropColumn(
                name: "Quantité",
                table: "DetailsFactureFournisseurs");

            migrationBuilder.DropColumn(
                name: "PrixTotale",
                table: "DetailsFactureClients");

            migrationBuilder.DropColumn(
                name: "Quantité",
                table: "DetailsFactureClients");

            migrationBuilder.DropColumn(
                name: "PrixTotale",
                table: "DetailsDevis");

            migrationBuilder.DropColumn(
                name: "Quantité",
                table: "DetailsDevis");

            migrationBuilder.DropColumn(
                name: "PrixTotale",
                table: "DetailsCommandeFournisseurs");

            migrationBuilder.DropColumn(
                name: "Quantité",
                table: "DetailsCommandeFournisseurs");

            migrationBuilder.DropColumn(
                name: "PrixTotale",
                table: "DetailsCommandeClients");

            migrationBuilder.DropColumn(
                name: "Quantité",
                table: "DetailsCommandeClients");

            migrationBuilder.DropColumn(
                name: "PrixTotale",
                table: "DetailsBonSorties");

            migrationBuilder.DropColumn(
                name: "Quantité",
                table: "DetailsBonSorties");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "BonDeRéceptionFournisseurs");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "BonDeCommandeFournisseurs");
        }
    }
}
