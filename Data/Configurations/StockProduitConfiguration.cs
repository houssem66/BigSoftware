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
    internal class StockProduitConfiguration : IEntityTypeConfiguration<StockProduit>
    {
        public void Configure(EntityTypeBuilder<StockProduit> builder)
        {
            builder.HasKey(e => new { e.IdProduit, e.IdStock });
            builder.HasOne(b => b.Produit).WithMany(b => b.StockProduit);
            builder.HasOne(b => b.Stock).WithMany(b => b.StockProduit);
            builder.Property(x => x.Quantite).HasColumnType("decimal(18,2)");
            builder.Property(x => x.PrixTotaleHt).HasColumnType("decimal(18,2)");
            builder.Property(x => x.PrixTotaleTTc).HasColumnType("decimal(18,2)");
        }
    }
}
