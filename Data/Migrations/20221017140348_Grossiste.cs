using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Grossiste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GrossisteId",
                table: "Stocks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_GrossisteId",
                table: "Stocks",
                column: "GrossisteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_AspNetUsers_GrossisteId",
                table: "Stocks",
                column: "GrossisteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_AspNetUsers_GrossisteId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_GrossisteId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "GrossisteId",
                table: "Stocks");
        }
    }
}
