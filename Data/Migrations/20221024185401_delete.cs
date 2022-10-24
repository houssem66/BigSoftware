using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsReceptionFournisseurs_BonDeRéceptionFournisseurs_BonDeRéceptionId",
                table: "DetailsReceptionFournisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsReceptionFournisseurs_Produits_ProduitId",
                table: "DetailsReceptionFournisseurs");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantite",
                table: "DetailsReceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MontantTTc",
                table: "DetailsReceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MontantHt",
                table: "DetailsReceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrixTotaleTTc",
                table: "BonDeRéceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrixTotaleHt",
                table: "BonDeRéceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsReceptionFournisseurs_BonDeRéceptionFournisseurs_BonDeRéceptionId",
                table: "DetailsReceptionFournisseurs",
                column: "BonDeRéceptionId",
                principalTable: "BonDeRéceptionFournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsReceptionFournisseurs_Produits_ProduitId",
                table: "DetailsReceptionFournisseurs",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailsReceptionFournisseurs_BonDeRéceptionFournisseurs_BonDeRéceptionId",
                table: "DetailsReceptionFournisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailsReceptionFournisseurs_Produits_ProduitId",
                table: "DetailsReceptionFournisseurs");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantite",
                table: "DetailsReceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MontantTTc",
                table: "DetailsReceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MontantHt",
                table: "DetailsReceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrixTotaleTTc",
                table: "BonDeRéceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrixTotaleHt",
                table: "BonDeRéceptionFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsReceptionFournisseurs_BonDeRéceptionFournisseurs_BonDeRéceptionId",
                table: "DetailsReceptionFournisseurs",
                column: "BonDeRéceptionId",
                principalTable: "BonDeRéceptionFournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailsReceptionFournisseurs_Produits_ProduitId",
                table: "DetailsReceptionFournisseurs",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
