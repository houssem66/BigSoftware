using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Civility = table.Column<int>(type: "int", nullable: false),
                    Identifiant_fiscale = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    NumMobile = table.Column<int>(type: "int", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeClient = table.Column<int>(type: "int", nullable: true),
                    Cin = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Fournisseur_PersAContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fournisseur_Verified = table.Column<bool>(type: "bit", nullable: true),
                    Fournisseur_Rib = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fournisseur_CodePostale = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Fournisseur_SiteWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fournisseur_Numbureau = table.Column<int>(type: "int", nullable: true),
                    PersAContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Verified = table.Column<bool>(type: "bit", nullable: true),
                    Rib = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CodePostale = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    SiteWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numbureau = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
