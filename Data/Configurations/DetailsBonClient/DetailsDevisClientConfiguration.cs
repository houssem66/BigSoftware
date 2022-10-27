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
    internal class DetailsDevisClientConfiguration : IEntityTypeConfiguration<DetailsDevis>
    {
        public void Configure(EntityTypeBuilder<DetailsDevis> builder)
        {
            builder.HasKey(e => new { e.IdProduit, e.IdDevis });
            builder.HasOne(b => b.Produit).WithMany(b => b.DetailsDevis).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.IdProduit);
            builder.HasOne(b => b.Devis).WithMany(b => b.DetailsDevis).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.IdDevis);
            builder.Property(x => x.MontantHt).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MontantTTc).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Quantite).HasColumnType("decimal(18,2)");

        }
    }
}
