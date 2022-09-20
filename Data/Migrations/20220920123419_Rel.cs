using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Rel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fournisseurs_AspNetUsers_GrossisteId",
                table: "Fournisseurs");

            migrationBuilder.DropIndex(
                name: "IX_Fournisseurs_GrossisteId",
                table: "Fournisseurs");

            migrationBuilder.DropColumn(
                name: "GrossisteId",
                table: "Fournisseurs");

            migrationBuilder.AlterColumn<string>(
                name: "IdGrossiste",
                table: "Fournisseurs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypePrix = table.Column<int>(type: "int", nullable: false),
                    TVA = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockProduit",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdStock = table.Column<int>(type: "int", nullable: false),
                    Quantité = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrixTotale = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: true),
                    StockId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockProduit", x => new { x.IdProduit, x.IdStock });
                    table.ForeignKey(
                        name: "FK_StockProduit_Produit_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockProduit_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fournisseurs_IdGrossiste",
                table: "Fournisseurs",
                column: "IdGrossiste");

            migrationBuilder.CreateIndex(
                name: "IX_StockProduit_ProduitId",
                table: "StockProduit",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_StockProduit_StockId",
                table: "StockProduit",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fournisseurs_AspNetUsers_IdGrossiste",
                table: "Fournisseurs",
                column: "IdGrossiste",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fournisseurs_AspNetUsers_IdGrossiste",
                table: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "StockProduit");

            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Fournisseurs_IdGrossiste",
                table: "Fournisseurs");

            migrationBuilder.AlterColumn<int>(
                name: "IdGrossiste",
                table: "Fournisseurs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GrossisteId",
                table: "Fournisseurs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fournisseurs_GrossisteId",
                table: "Fournisseurs",
                column: "GrossisteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fournisseurs_AspNetUsers_GrossisteId",
                table: "Fournisseurs",
                column: "GrossisteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
