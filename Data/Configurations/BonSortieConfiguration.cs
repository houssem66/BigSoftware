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
    internal class BonSortieConfiguration : IEntityTypeConfiguration<BonSortie>
    {
        public void Configure(EntityTypeBuilder<BonSortie> builder)
        {
            builder.Property(x => x.Prix).HasColumnType("decimal(18,2)");
        }
    }
}
