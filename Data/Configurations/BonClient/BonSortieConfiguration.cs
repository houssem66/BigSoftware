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
            builder.Property(x => x.PrixTotaleHt).HasColumnType("decimal(18,2)");
            builder.Property(x => x.PrixTotaleTTc).HasColumnType("decimal(18,2)"); builder.HasOne(b => b.Grossiste).WithMany().HasForeignKey(f => f.GrossisteId);

        }
    }
}
