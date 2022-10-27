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
    internal class DetailsBonSortieClientConfiguration : IEntityTypeConfiguration<DetailsBonSortie>
    {
        public void Configure(EntityTypeBuilder<DetailsBonSortie> builder)
        {
            builder.HasKey(e => new { e.IdProduit, e.IdBonSortie });
            builder.HasOne(b => b.Produit).WithMany(b => b.DetailsBonSorties);
            builder.HasOne(b => b.BonSortie).WithMany(b => b.DetailsBonSorties);
            builder.Property(x => x.Quantite).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MontantHt).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MontantTTc).HasColumnType("decimal(18,2)");
        }
    }
}
