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
   internal class DetailsFactureFournisseurConfiguration:IEntityTypeConfiguration<DetailsFactureFournisseur>
    {
        public void Configure(EntityTypeBuilder<DetailsFactureFournisseur> builder)
        {
            builder.HasKey(e => new { e.IdProduit, e.IdFacutre });
            builder.HasOne(b => b.Produit).WithMany(b => b.DetailsFactures);
            builder.HasOne(b => b.FactureFournisseur).WithMany(b => b.DetailsFactures);
            builder.Property(x => x.Quantite).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MontantHt).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MontantTTc).HasColumnType("decimal(18,2)");

        }


    }
}
