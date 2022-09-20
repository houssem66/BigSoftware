using Data.Configurations;
using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class BigSoftContext :  IdentityDbContext<Utilisateur>
    {
        public BigSoftContext(DbContextOptions<BigSoftContext> options) : base(options)
        {

        }
       //Dbset
       //Sprint1
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Grossiste> Grossistes { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Client> Clients { get; set; }
        //Sprint2
        public DbSet<Document> Documents { get; set; }
        public DbSet<DetailsReceptionFournisseur> DetailsReceptionFournisseurs { get; set; }
        public DbSet<DetailsFactureFournisseur> DetailsFactureFournisseurs { get; set; }
        public DbSet<DetailsCommandeFournisseur> DetailsCommandeFournisseurs { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<StockProduit> StockProduits { get; set; }
        public DbSet<BonDeCommandeFournisseur> BonDeCommandeFournisseurs { get; set; }
        public DbSet<BonDeRéceptionFournisseur> BonDeRéceptionFournisseurs { get; set; }
        public DbSet<FactureFournisseur> FactureFournisseurs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Sprint 1
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new GrossisteConfiguration());
            //Sprint2
            builder.ApplyConfiguration(new FournisseurConfiguration());
            builder.ApplyConfiguration(new StockProduitConfiguration());
            builder.ApplyConfiguration(new DetailsCommandeFournisseurConfiguration());
            builder.ApplyConfiguration(new DetailsBonReceptionFournisseurConfiguration());
            builder.ApplyConfiguration(new DetailsFactureFournisseurConfiguration());
            builder.ApplyConfiguration(new ProduitConfiguration());
        }
    }
}
