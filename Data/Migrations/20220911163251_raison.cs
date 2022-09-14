using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class raison : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RaisonSocial",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RaisonSocial",
                table: "AspNetUsers");
        }
    }
}
