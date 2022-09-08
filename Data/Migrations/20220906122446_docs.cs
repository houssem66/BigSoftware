using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class docs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AspNetUsers_UtilisateurId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "UtilisateurId",
                table: "Documents",
                newName: "GrossisteId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_UtilisateurId",
                table: "Documents",
                newName: "IX_Documents_GrossisteId");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AspNetUsers_GrossisteId",
                table: "Documents",
                column: "GrossisteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AspNetUsers_GrossisteId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "GrossisteId",
                table: "Documents",
                newName: "UtilisateurId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_GrossisteId",
                table: "Documents",
                newName: "IX_Documents_UtilisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AspNetUsers_UtilisateurId",
                table: "Documents",
                column: "UtilisateurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
