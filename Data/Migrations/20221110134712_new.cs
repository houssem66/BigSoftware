using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Civility = table.Column<int>(type: "int", nullable: false),
                    Gouvernorats = table.Column<int>(type: "int", nullable: false),
                    NumMobile = table.Column<int>(type: "int", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePostale = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RaisonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomPersAContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrenomPersAContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Verified = table.Column<bool>(type: "bit", nullable: true),
                    Rib = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SiteWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numbureau = table.Column<int>(type: "int", nullable: true),
                    NumFax = table.Column<int>(type: "int", nullable: true),
                    Identifiant_fiscale = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    EmailPersAContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneBureau = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Civility = table.Column<int>(type: "int", nullable: false),
                    Identifiant_fiscale = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    NumMobile = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Gouvernorats = table.Column<int>(type: "int", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePostale = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    TypeClient = table.Column<int>(type: "int", nullable: false),
                    Cin = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    IdGrossiste = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_IdGrossiste",
                        column: x => x.IdGrossiste,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossisteId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_AspNetUsers_GrossisteId",
                        column: x => x.GrossisteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPersAContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RaisonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrenomPersAContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostale = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormeJuridique = table.Column<int>(type: "int", nullable: false),
                    SiteWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneBureau = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Identifiant_fiscale = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    NumMobile = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Gouvernorats = table.Column<int>(type: "int", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Civility = table.Column<int>(type: "int", nullable: false),
                    IdGrossiste = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fournisseurs_AspNetUsers_IdGrossiste",
                        column: x => x.IdGrossiste,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TVA = table.Column<int>(type: "int", nullable: false),
                    PriceTTc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceHt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasure = table.Column<int>(type: "int", nullable: false),
                    IdGrossiste = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produits_AspNetUsers_IdGrossiste",
                        column: x => x.IdGrossiste,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossisteId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_AspNetUsers_GrossisteId",
                        column: x => x.GrossisteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonCommandeClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    GrossisteId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonCommandeClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonCommandeClients_AspNetUsers_GrossisteId",
                        column: x => x.GrossisteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BonCommandeClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonLivraisonClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    GrossisteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonLivraisonClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonLivraisonClients_AspNetUsers_GrossisteId",
                        column: x => x.GrossisteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BonLivraisonClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonSorties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrossisteId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonSorties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonSorties_AspNetUsers_GrossisteId",
                        column: x => x.GrossisteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BonSorties_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrossisteId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devis_AspNetUsers_GrossisteId",
                        column: x => x.GrossisteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devis_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonDeCommandeFournisseurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FournisseurId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrossisteId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonDeCommandeFournisseurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonDeCommandeFournisseurs_AspNetUsers_GrossisteId",
                        column: x => x.GrossisteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BonDeCommandeFournisseurs_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonDeRéceptionFournisseurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    FournisseurId = table.Column<int>(type: "int", nullable: false),
                    GrossisteId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonDeRéceptionFournisseurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonDeRéceptionFournisseurs_AspNetUsers_GrossisteId",
                        column: x => x.GrossisteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BonDeRéceptionFournisseurs_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockProduits",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdStock = table.Column<int>(type: "int", nullable: false),
                    PrixTotaleTTc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrixTotaleHt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantite = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockProduits", x => new { x.IdProduit, x.IdStock });
                    table.ForeignKey(
                        name: "FK_StockProduits_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockProduits_Stocks_IdStock",
                        column: x => x.IdStock,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailsCommandeClients",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdCommande = table.Column<int>(type: "int", nullable: false),
                    MontantTTc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantHt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantite = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsCommandeClients", x => new { x.IdProduit, x.IdCommande });
                    table.ForeignKey(
                        name: "FK_DetailsCommandeClients_BonCommandeClients_IdCommande",
                        column: x => x.IdCommande,
                        principalTable: "BonCommandeClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsCommandeClients_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailsLivraisonClients",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdBonLivraison = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantTTc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantHt = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsLivraisonClients", x => new { x.IdProduit, x.IdBonLivraison });
                    table.ForeignKey(
                        name: "FK_DetailsLivraisonClients_BonLivraisonClients_IdBonLivraison",
                        column: x => x.IdBonLivraison,
                        principalTable: "BonLivraisonClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsLivraisonClients_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactureClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BonLivraisonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactureClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactureClients_BonLivraisonClients_BonLivraisonId",
                        column: x => x.BonLivraisonId,
                        principalTable: "BonLivraisonClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailsBonSorties",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdBonSortie = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantTTc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantHt = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsBonSorties", x => new { x.IdProduit, x.IdBonSortie });
                    table.ForeignKey(
                        name: "FK_DetailsBonSorties_BonSorties_IdBonSortie",
                        column: x => x.IdBonSortie,
                        principalTable: "BonSorties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsBonSorties_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailsDevis",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdDevis = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantTTc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantHt = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsDevis", x => new { x.IdProduit, x.IdDevis });
                    table.ForeignKey(
                        name: "FK_DetailsDevis_Devis_IdDevis",
                        column: x => x.IdDevis,
                        principalTable: "Devis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsDevis_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailsCommandeFournisseurs",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdBonCommande = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantTTc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantHt = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsCommandeFournisseurs", x => new { x.IdProduit, x.IdBonCommande });
                    table.ForeignKey(
                        name: "FK_DetailsCommandeFournisseurs_BonDeCommandeFournisseurs_IdBonCommande",
                        column: x => x.IdBonCommande,
                        principalTable: "BonDeCommandeFournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsCommandeFournisseurs_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailsReceptionFournisseurs",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdBonReception = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantTTc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantHt = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsReceptionFournisseurs", x => new { x.IdProduit, x.IdBonReception });
                    table.ForeignKey(
                        name: "FK_DetailsReceptionFournisseurs_BonDeRéceptionFournisseurs_IdBonReception",
                        column: x => x.IdBonReception,
                        principalTable: "BonDeRéceptionFournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsReceptionFournisseurs_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactureFournisseurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BonDeReceptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactureFournisseurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactureFournisseurs_BonDeRéceptionFournisseurs_BonDeReceptionId",
                        column: x => x.BonDeReceptionId,
                        principalTable: "BonDeRéceptionFournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailsFactureClients",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdFactureClient = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantTTc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantHt = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsFactureClients", x => new { x.IdProduit, x.IdFactureClient });
                    table.ForeignKey(
                        name: "FK_DetailsFactureClients_FactureClients_IdFactureClient",
                        column: x => x.IdFactureClient,
                        principalTable: "FactureClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsFactureClients_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailsFactureFournisseurs",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdFacutre = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantTTc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantHt = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsFactureFournisseurs", x => new { x.IdProduit, x.IdFacutre });
                    table.ForeignKey(
                        name: "FK_DetailsFactureFournisseurs_FactureFournisseurs_IdFacutre",
                        column: x => x.IdFacutre,
                        principalTable: "FactureFournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsFactureFournisseurs_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BonCommandeClients_ClientId",
                table: "BonCommandeClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BonCommandeClients_GrossisteId",
                table: "BonCommandeClients",
                column: "GrossisteId");

            migrationBuilder.CreateIndex(
                name: "IX_BonDeCommandeFournisseurs_FournisseurId",
                table: "BonDeCommandeFournisseurs",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_BonDeCommandeFournisseurs_GrossisteId",
                table: "BonDeCommandeFournisseurs",
                column: "GrossisteId");

            migrationBuilder.CreateIndex(
                name: "IX_BonDeRéceptionFournisseurs_FournisseurId",
                table: "BonDeRéceptionFournisseurs",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_BonDeRéceptionFournisseurs_GrossisteId",
                table: "BonDeRéceptionFournisseurs",
                column: "GrossisteId");

            migrationBuilder.CreateIndex(
                name: "IX_BonLivraisonClients_ClientId",
                table: "BonLivraisonClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BonLivraisonClients_GrossisteId",
                table: "BonLivraisonClients",
                column: "GrossisteId");

            migrationBuilder.CreateIndex(
                name: "IX_BonSorties_ClientId",
                table: "BonSorties",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BonSorties_GrossisteId",
                table: "BonSorties",
                column: "GrossisteId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdGrossiste",
                table: "Clients",
                column: "IdGrossiste");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsBonSorties_IdBonSortie",
                table: "DetailsBonSorties",
                column: "IdBonSortie");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsCommandeClients_IdCommande",
                table: "DetailsCommandeClients",
                column: "IdCommande");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsCommandeFournisseurs_IdBonCommande",
                table: "DetailsCommandeFournisseurs",
                column: "IdBonCommande");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsDevis_IdDevis",
                table: "DetailsDevis",
                column: "IdDevis");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsFactureClients_IdFactureClient",
                table: "DetailsFactureClients",
                column: "IdFactureClient");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsFactureFournisseurs_IdFacutre",
                table: "DetailsFactureFournisseurs",
                column: "IdFacutre");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsLivraisonClients_IdBonLivraison",
                table: "DetailsLivraisonClients",
                column: "IdBonLivraison");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsReceptionFournisseurs_IdBonReception",
                table: "DetailsReceptionFournisseurs",
                column: "IdBonReception");

            migrationBuilder.CreateIndex(
                name: "IX_Devis_ClientId",
                table: "Devis",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Devis_GrossisteId",
                table: "Devis",
                column: "GrossisteId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_GrossisteId",
                table: "Documents",
                column: "GrossisteId");

            migrationBuilder.CreateIndex(
                name: "IX_FactureClients_BonLivraisonId",
                table: "FactureClients",
                column: "BonLivraisonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FactureFournisseurs_BonDeReceptionId",
                table: "FactureFournisseurs",
                column: "BonDeReceptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fournisseurs_IdGrossiste",
                table: "Fournisseurs",
                column: "IdGrossiste");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_IdGrossiste",
                table: "Produits",
                column: "IdGrossiste");

            migrationBuilder.CreateIndex(
                name: "IX_StockProduits_IdStock",
                table: "StockProduits",
                column: "IdStock");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_GrossisteId",
                table: "Stocks",
                column: "GrossisteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DetailsBonSorties");

            migrationBuilder.DropTable(
                name: "DetailsCommandeClients");

            migrationBuilder.DropTable(
                name: "DetailsCommandeFournisseurs");

            migrationBuilder.DropTable(
                name: "DetailsDevis");

            migrationBuilder.DropTable(
                name: "DetailsFactureClients");

            migrationBuilder.DropTable(
                name: "DetailsFactureFournisseurs");

            migrationBuilder.DropTable(
                name: "DetailsLivraisonClients");

            migrationBuilder.DropTable(
                name: "DetailsReceptionFournisseurs");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "StockProduits");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BonSorties");

            migrationBuilder.DropTable(
                name: "BonCommandeClients");

            migrationBuilder.DropTable(
                name: "BonDeCommandeFournisseurs");

            migrationBuilder.DropTable(
                name: "Devis");

            migrationBuilder.DropTable(
                name: "FactureClients");

            migrationBuilder.DropTable(
                name: "FactureFournisseurs");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "BonLivraisonClients");

            migrationBuilder.DropTable(
                name: "BonDeRéceptionFournisseurs");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
