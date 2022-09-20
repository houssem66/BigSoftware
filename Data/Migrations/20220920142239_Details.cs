using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BonDeCommandeFournisseur_Fournisseurs_FournisseurId",
                table: "BonDeCommandeFournisseur");

            migrationBuilder.DropForeignKey(
                name: "FK_BonDeRéceptionFournisseur_Fournisseurs_FournisseurId",
                table: "BonDeRéceptionFournisseur");

            migrationBuilder.DropForeignKey(
                name: "FK_FactureFournisseur_Fournisseurs_FournisseurId",
                table: "FactureFournisseur");

            migrationBuilder.DropForeignKey(
                name: "FK_StockProduit_Produit_ProduitId",
                table: "StockProduit");

            migrationBuilder.DropForeignKey(
                name: "FK_StockProduit_Stock_StockId",
                table: "StockProduit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockProduit",
                table: "StockProduit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produit",
                table: "Produit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FactureFournisseur",
                table: "FactureFournisseur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BonDeRéceptionFournisseur",
                table: "BonDeRéceptionFournisseur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BonDeCommandeFournisseur",
                table: "BonDeCommandeFournisseur");

            migrationBuilder.RenameTable(
                name: "StockProduit",
                newName: "StockProduits");

            migrationBuilder.RenameTable(
                name: "Stock",
                newName: "Stocks");

            migrationBuilder.RenameTable(
                name: "Produit",
                newName: "Produits");

            migrationBuilder.RenameTable(
                name: "FactureFournisseur",
                newName: "FactureFournisseurs");

            migrationBuilder.RenameTable(
                name: "BonDeRéceptionFournisseur",
                newName: "BonDeRéceptionFournisseurs");

            migrationBuilder.RenameTable(
                name: "BonDeCommandeFournisseur",
                newName: "BonDeCommandeFournisseurs");

            migrationBuilder.RenameIndex(
                name: "IX_StockProduit_StockId",
                table: "StockProduits",
                newName: "IX_StockProduits_StockId");

            migrationBuilder.RenameIndex(
                name: "IX_StockProduit_ProduitId",
                table: "StockProduits",
                newName: "IX_StockProduits_ProduitId");

            migrationBuilder.RenameIndex(
                name: "IX_FactureFournisseur_FournisseurId",
                table: "FactureFournisseurs",
                newName: "IX_FactureFournisseurs_FournisseurId");

            migrationBuilder.RenameIndex(
                name: "IX_BonDeRéceptionFournisseur_FournisseurId",
                table: "BonDeRéceptionFournisseurs",
                newName: "IX_BonDeRéceptionFournisseurs_FournisseurId");

            migrationBuilder.RenameIndex(
                name: "IX_BonDeCommandeFournisseur_FournisseurId",
                table: "BonDeCommandeFournisseurs",
                newName: "IX_BonDeCommandeFournisseurs_FournisseurId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockProduits",
                table: "StockProduits",
                columns: new[] { "IdProduit", "IdStock" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produits",
                table: "Produits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FactureFournisseurs",
                table: "FactureFournisseurs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BonDeRéceptionFournisseurs",
                table: "BonDeRéceptionFournisseurs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BonDeCommandeFournisseurs",
                table: "BonDeCommandeFournisseurs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DetailsCommandeFournisseurs",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdBonCommande = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: true),
                    BonDeCommandeFournisseurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsCommandeFournisseurs", x => new { x.IdProduit, x.IdBonCommande });
                    table.ForeignKey(
                        name: "FK_DetailsCommandeFournisseurs_BonDeCommandeFournisseurs_BonDeCommandeFournisseurId",
                        column: x => x.BonDeCommandeFournisseurId,
                        principalTable: "BonDeCommandeFournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailsCommandeFournisseurs_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailsFactureFournisseurs",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdFacutre = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: true),
                    FactureFournisseurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsFactureFournisseurs", x => new { x.IdProduit, x.IdFacutre });
                    table.ForeignKey(
                        name: "FK_DetailsFactureFournisseurs_FactureFournisseurs_FactureFournisseurId",
                        column: x => x.FactureFournisseurId,
                        principalTable: "FactureFournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailsFactureFournisseurs_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailsReceptionFournisseurs",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdBonReception = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: true),
                    BonDeRéceptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsReceptionFournisseurs", x => new { x.IdProduit, x.IdBonReception });
                    table.ForeignKey(
                        name: "FK_DetailsReceptionFournisseurs_BonDeRéceptionFournisseurs_BonDeRéceptionId",
                        column: x => x.BonDeRéceptionId,
                        principalTable: "BonDeRéceptionFournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailsReceptionFournisseurs_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailsCommandeFournisseurs_BonDeCommandeFournisseurId",
                table: "DetailsCommandeFournisseurs",
                column: "BonDeCommandeFournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsCommandeFournisseurs_ProduitId",
                table: "DetailsCommandeFournisseurs",
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
                name: "IX_DetailsReceptionFournisseurs_BonDeRéceptionId",
                table: "DetailsReceptionFournisseurs",
                column: "BonDeRéceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsReceptionFournisseurs_ProduitId",
                table: "DetailsReceptionFournisseurs",
                column: "ProduitId");

            migrationBuilder.AddForeignKey(
                name: "FK_BonDeCommandeFournisseurs_Fournisseurs_FournisseurId",
                table: "BonDeCommandeFournisseurs",
                column: "FournisseurId",
                principalTable: "Fournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BonDeRéceptionFournisseurs_Fournisseurs_FournisseurId",
                table: "BonDeRéceptionFournisseurs",
                column: "FournisseurId",
                principalTable: "Fournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactureFournisseurs_Fournisseurs_FournisseurId",
                table: "FactureFournisseurs",
                column: "FournisseurId",
                principalTable: "Fournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProduits_Produits_ProduitId",
                table: "StockProduits",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProduits_Stocks_StockId",
                table: "StockProduits",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BonDeCommandeFournisseurs_Fournisseurs_FournisseurId",
                table: "BonDeCommandeFournisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_BonDeRéceptionFournisseurs_Fournisseurs_FournisseurId",
                table: "BonDeRéceptionFournisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_FactureFournisseurs_Fournisseurs_FournisseurId",
                table: "FactureFournisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_StockProduits_Produits_ProduitId",
                table: "StockProduits");

            migrationBuilder.DropForeignKey(
                name: "FK_StockProduits_Stocks_StockId",
                table: "StockProduits");

            migrationBuilder.DropTable(
                name: "DetailsCommandeFournisseurs");

            migrationBuilder.DropTable(
                name: "DetailsFactureFournisseurs");

            migrationBuilder.DropTable(
                name: "DetailsReceptionFournisseurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockProduits",
                table: "StockProduits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produits",
                table: "Produits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FactureFournisseurs",
                table: "FactureFournisseurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BonDeRéceptionFournisseurs",
                table: "BonDeRéceptionFournisseurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BonDeCommandeFournisseurs",
                table: "BonDeCommandeFournisseurs");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Stock");

            migrationBuilder.RenameTable(
                name: "StockProduits",
                newName: "StockProduit");

            migrationBuilder.RenameTable(
                name: "Produits",
                newName: "Produit");

            migrationBuilder.RenameTable(
                name: "FactureFournisseurs",
                newName: "FactureFournisseur");

            migrationBuilder.RenameTable(
                name: "BonDeRéceptionFournisseurs",
                newName: "BonDeRéceptionFournisseur");

            migrationBuilder.RenameTable(
                name: "BonDeCommandeFournisseurs",
                newName: "BonDeCommandeFournisseur");

            migrationBuilder.RenameIndex(
                name: "IX_StockProduits_StockId",
                table: "StockProduit",
                newName: "IX_StockProduit_StockId");

            migrationBuilder.RenameIndex(
                name: "IX_StockProduits_ProduitId",
                table: "StockProduit",
                newName: "IX_StockProduit_ProduitId");

            migrationBuilder.RenameIndex(
                name: "IX_FactureFournisseurs_FournisseurId",
                table: "FactureFournisseur",
                newName: "IX_FactureFournisseur_FournisseurId");

            migrationBuilder.RenameIndex(
                name: "IX_BonDeRéceptionFournisseurs_FournisseurId",
                table: "BonDeRéceptionFournisseur",
                newName: "IX_BonDeRéceptionFournisseur_FournisseurId");

            migrationBuilder.RenameIndex(
                name: "IX_BonDeCommandeFournisseurs_FournisseurId",
                table: "BonDeCommandeFournisseur",
                newName: "IX_BonDeCommandeFournisseur_FournisseurId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockProduit",
                table: "StockProduit",
                columns: new[] { "IdProduit", "IdStock" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produit",
                table: "Produit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FactureFournisseur",
                table: "FactureFournisseur",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BonDeRéceptionFournisseur",
                table: "BonDeRéceptionFournisseur",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BonDeCommandeFournisseur",
                table: "BonDeCommandeFournisseur",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BonDeCommandeFournisseur_Fournisseurs_FournisseurId",
                table: "BonDeCommandeFournisseur",
                column: "FournisseurId",
                principalTable: "Fournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BonDeRéceptionFournisseur_Fournisseurs_FournisseurId",
                table: "BonDeRéceptionFournisseur",
                column: "FournisseurId",
                principalTable: "Fournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactureFournisseur_Fournisseurs_FournisseurId",
                table: "FactureFournisseur",
                column: "FournisseurId",
                principalTable: "Fournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProduit_Produit_ProduitId",
                table: "StockProduit",
                column: "ProduitId",
                principalTable: "Produit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProduit_Stock_StockId",
                table: "StockProduit",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
