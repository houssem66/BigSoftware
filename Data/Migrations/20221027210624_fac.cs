using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactureFournisseurs_Fournisseurs_FournisseurId",
                table: "FactureFournisseurs");

            migrationBuilder.DropIndex(
                name: "IX_FactureFournisseurs_FournisseurId",
                table: "FactureFournisseurs");

            migrationBuilder.DropColumn(
                name: "FournisseurId",
                table: "FactureFournisseurs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FournisseurId",
                table: "FactureFournisseurs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FactureFournisseurs_FournisseurId",
                table: "FactureFournisseurs",
                column: "FournisseurId");

            migrationBuilder.AddForeignKey(
                name: "FK_FactureFournisseurs_Fournisseurs_FournisseurId",
                table: "FactureFournisseurs",
                column: "FournisseurId",
                principalTable: "Fournisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
