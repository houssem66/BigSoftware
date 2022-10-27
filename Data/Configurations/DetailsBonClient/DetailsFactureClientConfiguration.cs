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
    internal class DetailsFactureClientConfiguration : IEntityTypeConfiguration<DetailsFactureClient>
    {
        public void Configure(EntityTypeBuilder<DetailsFactureClient> builder)
        {
            builder.HasKey(e => new { e.IdProduit, e.IdFactureClient });
            builder.HasOne(b => b.Produit).WithMany(b => b.DetailsFactureClients).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.IdProduit);
            builder.HasOne(b => b.FactureClient).WithMany(b => b.DetailsFactures).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x => x.IdFactureClient);
            builder.Property(x => x.Quantite).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MontantHt).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MontantTTc).HasColumnType("decimal(18,2)");

        }
    }
}
