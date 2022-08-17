using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fournisseur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fournisseur_CodePostale",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fournisseur_Numbureau",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fournisseur_PersAContact",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fournisseur_Rib",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fournisseur_SiteWeb",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fournisseur_Verified",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPersAContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaisonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrenomPersAContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePostale = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numbureau = table.Column<int>(type: "int", nullable: false),
                    NumFax = table.Column<int>(type: "int", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Fournisseur_CodePostale",
                table: "AspNetUsers",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fournisseur_Numbureau",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fournisseur_PersAContact",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fournisseur_Rib",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fournisseur_SiteWeb",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Fournisseur_Verified",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Telephone",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
