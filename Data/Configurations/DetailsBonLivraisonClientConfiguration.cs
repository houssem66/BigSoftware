using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Configurations
{
    internal class DetailsBonLivraisonClientConfiguration : IEntityTypeConfiguration<DetailsLivraisonClient>
    {
        public void Configure(EntityTypeBuilder<DetailsLivraisonClient> builder)
        {
            builder.HasKey(e => new { e.IdProduit, e.IdBonLivraison });
            builder.HasOne(b => b.Produit).WithMany(b => b.DetailsLivraisons);
            builder.HasOne(b => b.BonLivraison).WithMany(b => b.DetailsLivraisons);
            builder.Property(x => x.Montant).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Quantite).HasColumnType("decimal(18,2)");

        }
    }
}
