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
    internal class DetailsBonCommandeClientConfiguration : IEntityTypeConfiguration<DetailsCommandeClient>
    {
        public void Configure(EntityTypeBuilder<DetailsCommandeClient> builder)
        {
            builder.HasKey(e => new { e.IdProduit, e.IdCommande });
            builder.HasOne(b => b.Produit).WithMany(b => b.DetailsCommandeClients);
            builder.HasOne(b => b.CommandeClient).WithMany(b => b.DetailsCommandes);
            builder.Property(e => e.Quantite).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MontantHt).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MontantTTc).HasColumnType("decimal(18,2)");

        }
    }
}
