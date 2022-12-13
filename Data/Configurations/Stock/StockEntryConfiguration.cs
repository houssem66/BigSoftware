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
    internal class StockEntryConfiguration :IEntityTypeConfiguration<StockProduitEntry>
    {
        public void Configure(EntityTypeBuilder<StockProduitEntry> builder)
        {
            builder.Property(x => x.Quantity).HasColumnType("decimal(18,2)");

        }
    }
}
