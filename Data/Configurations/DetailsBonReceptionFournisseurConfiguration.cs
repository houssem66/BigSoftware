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
            builder.HasOne(b => b.Produit).WithMany(b => b.DetailsReceptions);
            builder.HasOne(b => b.BonDeRéception).WithMany(b => b.DetailsReceptions);
            
        }
    }
}
