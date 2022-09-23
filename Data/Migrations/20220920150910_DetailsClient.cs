using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DetailsClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GrossisteId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdGrossiste",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BonCommandeClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonCommandeClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BonLivraisonClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonLivraisonClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BonSorties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonSorties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactureClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactureClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetailsCommandeClients",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdCommande = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: true),
                    CommandeClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsCommandeClients", x => new { x.IdProduit, x.IdCommande });
                    table.ForeignKey(
                        name: "FK_DetailsCommandeClients_BonCommandeClients_CommandeClientId",
                        column: x => x.CommandeClientId,
                        principalTable: "BonCommandeClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailsCommandeClients_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailsLivraisonClients",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdBonLivraison = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: true),
                    BonLivraisonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsLivraisonClients", x => new { x.IdProduit, x.IdBonLivraison });
                    table.ForeignKey(
                        name: "FK_DetailsLivraisonClients_BonLivraisonClients_BonLivraisonId",
                        column: x => x.BonLivraisonId,
                        principalTable: "BonLivraisonClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailsLivraisonClients_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailsBonSorties",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdBonSortie = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: true),
                    BonSortieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsBonSorties", x => new { x.IdProduit, x.IdBonSortie });
                    table.ForeignKey(
                        name: "FK_DetailsBonSorties_BonSorties_BonSortieId",
                        column: x => x.BonSortieId,
                        principalTable: "BonSorties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailsBonSorties_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailsDevis",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdDevis = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: true),
                    DevisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsDevis", x => new { x.IdProduit, x.IdDevis });
                    table.ForeignKey(
                        name: "FK_DetailsDevis_Devis_DevisId",
                        column: x => x.DevisId,
                        principalTable: "Devis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailsDevis_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailsFactureClients",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdFactureClient = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: true),
                    FactureClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsFactureClients", x => new { x.IdProduit, x.IdFactureClient });
                    table.ForeignKey(
                        name: "FK_DetailsFactureClients_FactureClients_FactureClientId",
                        column: x => x.FactureClientId,
                        principalTable: "FactureClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailsFactureClients_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_GrossisteId",
                table: "Clients",
                column: "GrossisteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsBonSorties_BonSortieId",
                table: "DetailsBonSorties",
                column: "BonSortieId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsBonSorties_ProduitId",
                table: "DetailsBonSorties",
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
                name: "IX_DetailsDevis_DevisId",
                table: "DetailsDevis",
                column: "DevisId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsDevis_ProduitId",
                table: "DetailsDevis",
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
                name: "IX_DetailsLivraisonClients_BonLivraisonId",
                table: "DetailsLivraisonClients",
                column: "BonLivraisonId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsLivraisonClients_ProduitId",
                table: "DetailsLivraisonClients",
                column: "ProduitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_GrossisteId",
                table: "Clients",
                column: "GrossisteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_GrossisteId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "DetailsBonSorties");

            migrationBuilder.DropTable(
                name: "DetailsCommandeClients");

            migrationBuilder.DropTable(
                name: "DetailsDevis");

            migrationBuilder.DropTable(
                name: "DetailsFactureClients");

            migrationBuilder.DropTable(
                name: "DetailsLivraisonClients");

            migrationBuilder.DropTable(
                name: "BonSorties");

            migrationBuilder.DropTable(
                name: "BonCommandeClients");

            migrationBuilder.DropTable(
                name: "Devis");

            migrationBuilder.DropTable(
                name: "FactureClients");

            migrationBuilder.DropTable(
                name: "BonLivraisonClients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_GrossisteId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "GrossisteId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IdGrossiste",
                table: "Clients");
        }
    }
}
