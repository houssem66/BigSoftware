using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsBonSorties_BonSorties_BonSortieId",
                table: "DetailsBonSorties");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsBonSorties_Produits_ProduitId",
                table: "DetailsBonSorties");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsCommandeClients_BonCommandeClients_CommandeClientId",
                table: "DetailsCommandeClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsCommandeClients_Produits_ProduitId",
                table: "DetailsCommandeClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsCommandeFournisseurs_BonDeCommandeFournisseurs_BonDeCommandeFournisseurId",
                table: "DetailsCommandeFournisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsCommandeFournisseurs_Produits_ProduitId",
                table: "DetailsCommandeFournisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsDevis_Devis_DevisId",
                table: "DetailsDevis");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsDevis_Produits_ProduitId",
                table: "DetailsDevis");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactureClients_FactureClients_FactureClientId",
                table: "DetailsFactureClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactureClients_Produits_ProduitId",
                table: "DetailsFactureClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactureFournisseurs_FactureFournisseurs_FactureFournisseurId",
                table: "DetailsFactureFournisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactureFournisseurs_Produits_ProduitId",
                table: "DetailsFactureFournisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsLivraisonClients_BonLivraisonClients_BonLivraisonId",
                table: "DetailsLivraisonClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsLivraisonClients_Produits_ProduitId",
                table: "DetailsLivraisonClients");

            migrationBuilder.DropIndex(
                name: "IX_DetailsLivraisonClients_BonLivraisonId",
                table: "DetailsLivraisonClients");

            migrationBuilder.DropIndex(
                name: "IX_DetailsLivraisonClients_ProduitId",
                table: "DetailsLivraisonClients");

            migrationBuilder.DropIndex(
                name: "IX_DetailsFactureFournisseurs_FactureFournisseurId",
                table: "DetailsFactureFournisseurs");

            migrationBuilder.DropIndex(
                name: "IX_DetailsFactureFournisseurs_ProduitId",
                table: "DetailsFactureFournisseurs");

            migrationBuilder.DropIndex(
                name: "IX_DetailsFactureClients_FactureClientId",
                table: "DetailsFactureClients");

            migrationBuilder.DropIndex(
                name: "IX_DetailsFactureClients_ProduitId",
                table: "DetailsFactureClients");

            migrationBuilder.DropIndex(
                name: "IX_DetailsDevis_DevisId",
                table: "DetailsDevis");

            migrationBuilder.DropIndex(
                name: "IX_DetailsDevis_ProduitId",
                table: "DetailsDevis");

            migrationBuilder.DropIndex(
                name: "IX_DetailsCommandeFournisseurs_BonDeCommandeFournisseurId",
                table: "DetailsCommandeFournisseurs");

            migrationBuilder.DropIndex(
                name: "IX_DetailsCommandeFournisseurs_ProduitId",
                table: "DetailsCommandeFournisseurs");

            migrationBuilder.DropIndex(
                name: "IX_DetailsCommandeClients_CommandeClientId",
                table: "DetailsCommandeClients");

            migrationBuilder.DropIndex(
                name: "IX_DetailsCommandeClients_ProduitId",
                table: "DetailsCommandeClients");

            migrationBuilder.DropIndex(
                name: "IX_DetailsBonSorties_BonSortieId",
                table: "DetailsBonSorties");

            migrationBuilder.DropIndex(
                name: "IX_DetailsBonSorties_ProduitId",
                table: "DetailsBonSorties");

            migrationBuilder.DropColumn(
                name: "BonLivraisonId",
                table: "DetailsLivraisonClients");

            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "DetailsLivraisonClients");

            migrationBuilder.DropColumn(
                name: "FactureFournisseurId",
                table: "DetailsFactureFournisseurs");

            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "DetailsFactureFournisseurs");

            migrationBuilder.DropColumn(
                name: "FactureClientId",
                table: "DetailsFactureClients");

            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "DetailsFactureClients");

            migrationBuilder.DropColumn(
                name: "DevisId",
                table: "DetailsDevis");

            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "DetailsDevis");

            migrationBuilder.DropColumn(
                name: "BonDeCommandeFournisseurId",
                table: "DetailsCommandeFournisseurs");

            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "DetailsCommandeFournisseurs");

            migrationBuilder.DropColumn(
                name: "CommandeClientId",
                table: "DetailsCommandeClients");

            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "DetailsCommandeClients");

            migrationBuilder.DropColumn(
                name: "BonSortieId",
                table: "DetailsBonSorties");

            migrationBuilder.DropColumn(
                name: "ProduitId",
                table: "DetailsBonSorties");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsLivraisonClients_IdBonLivraison",
                table: "DetailsLivraisonClients",
                column: "IdBonLivraison");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsFactureFournisseurs_IdFacutre",
                table: "DetailsFactureFournisseurs",
                column: "IdFacutre");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsFactureClients_IdFactureClient",
                table: "DetailsFactureClients",
                column: "IdFactureClient");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsDevis_IdDevis",
                table: "DetailsDevis",
                column: "IdDevis");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsCommandeFournisseurs_IdBonCommande",
                table: "DetailsCommandeFournisseurs",
                column: "IdBonCommande");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsCommandeClients_IdCommande",
                table: "DetailsCommandeClients",
                column: "IdCommande");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsBonSorties_IdBonSortie",
                table: "DetailsBonSorties",
                column: "IdBonSortie");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsBonSorties_BonSorties_IdBonSortie",
                table: "DetailsBonSorties",
                column: "IdBonSortie",
                principalTable: "BonSorties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsBonSorties_Produits_IdProduit",
                table: "DetailsBonSorties",
                column: "IdProduit",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsCommandeClients_BonCommandeClients_IdCommande",
                table: "DetailsCommandeClients",
                column: "IdCommande",
                principalTable: "BonCommandeClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsCommandeClients_Produits_IdProduit",
                table: "DetailsCommandeClients",
                column: "IdProduit",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsCommandeFournisseurs_BonDeCommandeFournisseurs_IdBonCommande",
                table: "DetailsCommandeFournisseurs",
                column: "IdBonCommande",
                principalTable: "BonDeCommandeFournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsCommandeFournisseurs_Produits_IdProduit",
                table: "DetailsCommandeFournisseurs",
                column: "IdProduit",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsDevis_Devis_IdDevis",
                table: "DetailsDevis",
                column: "IdDevis",
                principalTable: "Devis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsDevis_Produits_IdProduit",
                table: "DetailsDevis",
                column: "IdProduit",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactureClients_FactureClients_IdFactureClient",
                table: "DetailsFactureClients",
                column: "IdFactureClient",
                principalTable: "FactureClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactureClients_Produits_IdProduit",
                table: "DetailsFactureClients",
                column: "IdProduit",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactureFournisseurs_FactureFournisseurs_IdFacutre",
                table: "DetailsFactureFournisseurs",
                column: "IdFacutre",
                principalTable: "FactureFournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactureFournisseurs_Produits_IdProduit",
                table: "DetailsFactureFournisseurs",
                column: "IdProduit",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsLivraisonClients_BonLivraisonClients_IdBonLivraison",
                table: "DetailsLivraisonClients",
                column: "IdBonLivraison",
                principalTable: "BonLivraisonClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsLivraisonClients_Produits_IdProduit",
                table: "DetailsLivraisonClients",
                column: "IdProduit",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsBonSorties_BonSorties_IdBonSortie",
                table: "DetailsBonSorties");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsBonSorties_Produits_IdProduit",
                table: "DetailsBonSorties");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsCommandeClients_BonCommandeClients_IdCommande",
                table: "DetailsCommandeClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsCommandeClients_Produits_IdProduit",
                table: "DetailsCommandeClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsCommandeFournisseurs_BonDeCommandeFournisseurs_IdBonCommande",
                table: "DetailsCommandeFournisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsCommandeFournisseurs_Produits_IdProduit",
                table: "DetailsCommandeFournisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsDevis_Devis_IdDevis",
                table: "DetailsDevis");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsDevis_Produits_IdProduit",
                table: "DetailsDevis");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactureClients_FactureClients_IdFactureClient",
                table: "DetailsFactureClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactureClients_Produits_IdProduit",
                table: "DetailsFactureClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactureFournisseurs_FactureFournisseurs_IdFacutre",
                table: "DetailsFactureFournisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsFactureFournisseurs_Produits_IdProduit",
                table: "DetailsFactureFournisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsLivraisonClients_BonLivraisonClients_IdBonLivraison",
                table: "DetailsLivraisonClients");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsLivraisonClients_Produits_IdProduit",
                table: "DetailsLivraisonClients");

            migrationBuilder.DropIndex(
                name: "IX_DetailsLivraisonClients_IdBonLivraison",
                table: "DetailsLivraisonClients");

            migrationBuilder.DropIndex(
                name: "IX_DetailsFactureFournisseurs_IdFacutre",
                table: "DetailsFactureFournisseurs");

            migrationBuilder.DropIndex(
                name: "IX_DetailsFactureClients_IdFactureClient",
                table: "DetailsFactureClients");

            migrationBuilder.DropIndex(
                name: "IX_DetailsDevis_IdDevis",
                table: "DetailsDevis");

            migrationBuilder.DropIndex(
                name: "IX_DetailsCommandeFournisseurs_IdBonCommande",
                table: "DetailsCommandeFournisseurs");

            migrationBuilder.DropIndex(
                name: "IX_DetailsCommandeClients_IdCommande",
                table: "DetailsCommandeClients");

            migrationBuilder.DropIndex(
                name: "IX_DetailsBonSorties_IdBonSortie",
                table: "DetailsBonSorties");

            migrationBuilder.AddColumn<int>(
                name: "BonLivraisonId",
                table: "DetailsLivraisonClients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "DetailsLivraisonClients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactureFournisseurId",
                table: "DetailsFactureFournisseurs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "DetailsFactureFournisseurs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactureClientId",
                table: "DetailsFactureClients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "DetailsFactureClients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DevisId",
                table: "DetailsDevis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "DetailsDevis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BonDeCommandeFournisseurId",
                table: "DetailsCommandeFournisseurs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "DetailsCommandeFournisseurs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommandeClientId",
                table: "DetailsCommandeClients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "DetailsCommandeClients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BonSortieId",
                table: "DetailsBonSorties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProduitId",
                table: "DetailsBonSorties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailsLivraisonClients_BonLivraisonId",
                table: "DetailsLivraisonClients",
                column: "BonLivraisonId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsLivraisonClients_ProduitId",
                table: "DetailsLivraisonClients",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsFactureFournisseurs_FactureFournisseurId",
                table: "DetailsFactureFournisseurs",
                column: "FactureFournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsFactureFournisseurs_ProduitId",
                table: "DetailsFactureFournisseurs",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsFactureClients_FactureClientId",
                table: "DetailsFactureClients",
                column: "FactureClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsFactureClients_ProduitId",
                table: "DetailsFactureClients",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsDevis_DevisId",
                table: "DetailsDevis",
                column: "DevisId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsDevis_ProduitId",
                table: "DetailsDevis",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsCommandeFournisseurs_BonDeCommandeFournisseurId",
                table: "DetailsCommandeFournisseurs",
                column: "BonDeCommandeFournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsCommandeFournisseurs_ProduitId",
                table: "DetailsCommandeFournisseurs",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsCommandeClients_CommandeClientId",
                table: "DetailsCommandeClients",
                column: "CommandeClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsCommandeClients_ProduitId",
                table: "DetailsCommandeClients",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsBonSorties_BonSortieId",
                table: "DetailsBonSorties",
                column: "BonSortieId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsBonSorties_ProduitId",
                table: "DetailsBonSorties",
                column: "ProduitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsBonSorties_BonSorties_BonSortieId",
                table: "DetailsBonSorties",
                column: "BonSortieId",
                principalTable: "BonSorties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsBonSorties_Produits_ProduitId",
                table: "DetailsBonSorties",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsCommandeClients_BonCommandeClients_CommandeClientId",
                table: "DetailsCommandeClients",
                column: "CommandeClientId",
                principalTable: "BonCommandeClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsCommandeClients_Produits_ProduitId",
                table: "DetailsCommandeClients",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsCommandeFournisseurs_BonDeCommandeFournisseurs_BonDeCommandeFournisseurId",
                table: "DetailsCommandeFournisseurs",
                column: "BonDeCommandeFournisseurId",
                principalTable: "BonDeCommandeFournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsCommandeFournisseurs_Produits_ProduitId",
                table: "DetailsCommandeFournisseurs",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsDevis_Devis_DevisId",
                table: "DetailsDevis",
                column: "DevisId",
                principalTable: "Devis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsDevis_Produits_ProduitId",
                table: "DetailsDevis",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactureClients_FactureClients_FactureClientId",
                table: "DetailsFactureClients",
                column: "FactureClientId",
                principalTable: "FactureClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactureClients_Produits_ProduitId",
                table: "DetailsFactureClients",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactureFournisseurs_FactureFournisseurs_FactureFournisseurId",
                table: "DetailsFactureFournisseurs",
                column: "FactureFournisseurId",
                principalTable: "FactureFournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsFactureFournisseurs_Produits_ProduitId",
                table: "DetailsFactureFournisseurs",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsLivraisonClients_BonLivraisonClients_BonLivraisonId",
                table: "DetailsLivraisonClients",
                column: "BonLivraisonId",
                principalTable: "BonLivraisonClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsLivraisonClients_Produits_ProduitId",
                table: "DetailsLivraisonClients",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
