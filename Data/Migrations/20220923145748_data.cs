using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantité",
                table: "StockProduits",
                newName: "Quantite");

            migrationBuilder.RenameColumn(
                name: "Quantité",
                table: "DetailsReceptionFournisseurs",
                newName: "Quantite");

            migrationBuilder.RenameColumn(
                name: "PrixTotale",
                table: "DetailsReceptionFournisseurs",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "Quantité",
                table: "DetailsLivraisonClients",
                newName: "Quantite");

            migrationBuilder.RenameColumn(
                name: "PrixTotale",
                table: "DetailsLivraisonClients",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "Quantité",
                table: "DetailsFactureFournisseurs",
                newName: "Quantite");

            migrationBuilder.RenameColumn(
                name: "PrixTotale",
                table: "DetailsFactureFournisseurs",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "Quantité",
                table: "DetailsFactureClients",
                newName: "Quantite");

            migrationBuilder.RenameColumn(
                name: "PrixTotale",
                table: "DetailsFactureClients",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "Quantité",
                table: "DetailsDevis",
                newName: "Quantite");

            migrationBuilder.RenameColumn(
                name: "PrixTotale",
                table: "DetailsDevis",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "Quantité",
                table: "DetailsCommandeFournisseurs",
                newName: "Quantite");

            migrationBuilder.RenameColumn(
                name: "PrixTotale",
                table: "DetailsCommandeFournisseurs",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "Quantité",
                table: "DetailsCommandeClients",
                newName: "Quantite");

            migrationBuilder.RenameColumn(
                name: "PrixTotale",
                table: "DetailsCommandeClients",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "Quantité",
                table: "DetailsBonSorties",
                newName: "Quantite");

            migrationBuilder.RenameColumn(
                name: "PrixTotale",
                table: "DetailsBonSorties",
                newName: "Montant");

            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "FactureFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "FactureClients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "FactureClients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "FactureClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Devis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Devis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "Devis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "BonSorties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BonSorties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "BonSorties",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "BonLivraisonClients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BonLivraisonClients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "BonLivraisonClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "BonDeRéceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "BonDeCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "BonCommandeClients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BonCommandeClients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "BonCommandeClients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_FactureClients_ClientId",
                table: "FactureClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Devis_ClientId",
                table: "Devis",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BonSorties_ClientId",
                table: "BonSorties",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BonLivraisonClients_ClientId",
                table: "BonLivraisonClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BonCommandeClients_ClientId",
                table: "BonCommandeClients",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_BonCommandeClients_Clients_ClientId",
                table: "BonCommandeClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BonLivraisonClients_Clients_ClientId",
                table: "BonLivraisonClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BonSorties_Clients_ClientId",
                table: "BonSorties",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devis_Clients_ClientId",
                table: "Devis",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactureClients_Clients_ClientId",
                table: "FactureClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BonCommandeClients_Clients_ClientId",
                table: "BonCommandeClients");

            migrationBuilder.DropForeignKey(
                name: "FK_BonLivraisonClients_Clients_ClientId",
                table: "BonLivraisonClients");

            migrationBuilder.DropForeignKey(
                name: "FK_BonSorties_Clients_ClientId",
                table: "BonSorties");

            migrationBuilder.DropForeignKey(
                name: "FK_Devis_Clients_ClientId",
                table: "Devis");

            migrationBuilder.DropForeignKey(
                name: "FK_FactureClients_Clients_ClientId",
                table: "FactureClients");

            migrationBuilder.DropIndex(
                name: "IX_FactureClients_ClientId",
                table: "FactureClients");

            migrationBuilder.DropIndex(
                name: "IX_Devis_ClientId",
                table: "Devis");

            migrationBuilder.DropIndex(
                name: "IX_BonSorties_ClientId",
                table: "BonSorties");

            migrationBuilder.DropIndex(
                name: "IX_BonLivraisonClients_ClientId",
                table: "BonLivraisonClients");

            migrationBuilder.DropIndex(
                name: "IX_BonCommandeClients_ClientId",
                table: "BonCommandeClients");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "FactureFournisseurs");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "FactureClients");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "FactureClients");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "FactureClients");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Devis");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Devis");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Devis");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "BonSorties");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "BonSorties");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "BonSorties");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "BonLivraisonClients");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "BonLivraisonClients");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "BonLivraisonClients");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "BonDeRéceptionFournisseurs");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "BonDeCommandeFournisseurs");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "BonCommandeClients");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "BonCommandeClients");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "BonCommandeClients");

            migrationBuilder.RenameColumn(
                name: "Quantite",
                table: "StockProduits",
                newName: "Quantité");

            migrationBuilder.RenameColumn(
                name: "Quantite",
                table: "DetailsReceptionFournisseurs",
                newName: "Quantité");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsReceptionFournisseurs",
                newName: "PrixTotale");

            migrationBuilder.RenameColumn(
                name: "Quantite",
                table: "DetailsLivraisonClients",
                newName: "Quantité");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsLivraisonClients",
                newName: "PrixTotale");

            migrationBuilder.RenameColumn(
                name: "Quantite",
                table: "DetailsFactureFournisseurs",
                newName: "Quantité");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsFactureFournisseurs",
                newName: "PrixTotale");

            migrationBuilder.RenameColumn(
                name: "Quantite",
                table: "DetailsFactureClients",
                newName: "Quantité");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsFactureClients",
                newName: "PrixTotale");

            migrationBuilder.RenameColumn(
                name: "Quantite",
                table: "DetailsDevis",
                newName: "Quantité");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsDevis",
                newName: "PrixTotale");

            migrationBuilder.RenameColumn(
                name: "Quantite",
                table: "DetailsCommandeFournisseurs",
                newName: "Quantité");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsCommandeFournisseurs",
                newName: "PrixTotale");

            migrationBuilder.RenameColumn(
                name: "Quantite",
                table: "DetailsCommandeClients",
                newName: "Quantité");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsCommandeClients",
                newName: "PrixTotale");

            migrationBuilder.RenameColumn(
                name: "Quantite",
                table: "DetailsBonSorties",
                newName: "Quantité");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "DetailsBonSorties",
                newName: "PrixTotale");
        }
    }
}
