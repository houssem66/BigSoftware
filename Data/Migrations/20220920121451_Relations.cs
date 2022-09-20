using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GrossisteId",
                table: "Fournisseurs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdGrossiste",
                table: "Fournisseurs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BonDeCommandeFournisseur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FournisseurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonDeCommandeFournisseur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonDeCommandeFournisseur_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonDeRéceptionFournisseur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FournisseurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonDeRéceptionFournisseur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonDeRéceptionFournisseur_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactureFournisseur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FournisseurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactureFournisseur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactureFournisseur_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fournisseurs_GrossisteId",
                table: "Fournisseurs",
                column: "GrossisteId");

            migrationBuilder.CreateIndex(
                name: "IX_BonDeCommandeFournisseur_FournisseurId",
                table: "BonDeCommandeFournisseur",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_BonDeRéceptionFournisseur_FournisseurId",
                table: "BonDeRéceptionFournisseur",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_FactureFournisseur_FournisseurId",
                table: "FactureFournisseur",
                column: "FournisseurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fournisseurs_AspNetUsers_GrossisteId",
                table: "Fournisseurs",
                column: "GrossisteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fournisseurs_AspNetUsers_GrossisteId",
                table: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "BonDeCommandeFournisseur");

            migrationBuilder.DropTable(
                name: "BonDeRéceptionFournisseur");

            migrationBuilder.DropTable(
                name: "FactureFournisseur");

            migrationBuilder.DropIndex(
                name: "IX_Fournisseurs_GrossisteId",
                table: "Fournisseurs");

            migrationBuilder.DropColumn(
                name: "GrossisteId",
                table: "Fournisseurs");

            migrationBuilder.DropColumn(
                name: "IdGrossiste",
                table: "Fournisseurs");
        }
    }
}
