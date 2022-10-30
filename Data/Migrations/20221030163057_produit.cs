using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class produit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdGrossiste",
                table: "Produits",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantite",
                table: "DetailsCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MontantTTc",
                table: "DetailsCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MontantHt",
                table: "DetailsCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrixTotaleTTc",
                table: "BonDeCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrixTotaleHt",
                table: "BonDeCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_IdGrossiste",
                table: "Produits",
                column: "IdGrossiste");

            migrationBuilder.AddForeignKey(
                name: "FK_Produits_AspNetUsers_IdGrossiste",
                table: "Produits",
                column: "IdGrossiste",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produits_AspNetUsers_IdGrossiste",
                table: "Produits");

            migrationBuilder.DropIndex(
                name: "IX_Produits_IdGrossiste",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "IdGrossiste",
                table: "Produits");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantite",
                table: "DetailsCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MontantTTc",
                table: "DetailsCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MontantHt",
                table: "DetailsCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrixTotaleTTc",
                table: "BonDeCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrixTotaleHt",
                table: "BonDeCommandeFournisseurs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
