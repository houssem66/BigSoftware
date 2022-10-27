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
    internal class DetailsBonReceptionFournisseurConfiguration : IEntityTypeConfiguration<DetailsReceptionFournisseur>
    {
        public void Configure(EntityTypeBuilder<DetailsReceptionFournisseur> builder)
        {
            builder.HasKey(e => new { e.IdProduit, e.IdBonReception });
            builder.HasOne(b => b.Produit).WithMany(b => b.DetailsReceptions).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x=>x.IdProduit) ;
            builder.HasOne(b => b.BonDeRéception).WithMany(b => b.DetailsReceptions).OnDelete(DeleteBehavior.Cascade).HasForeignKey(x=>x.IdBonReception) ;
            builder.Property(x => x.Quantite).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MontantHt).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MontantTTc).HasColumnType("decimal(18,2)");



        }
    }
}
