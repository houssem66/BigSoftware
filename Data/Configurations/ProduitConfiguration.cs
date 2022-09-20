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
    internal class ProduitConfiguration : IEntityTypeConfiguration<Produit>
    {
        public void Configure(EntityTypeBuilder<Produit> builder)
        {
            builder.Property(e => e.Price).HasColumnType("decimal(18,2)");
        }
    }
}
