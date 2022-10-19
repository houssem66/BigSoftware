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
    internal class DevisConfiguration : IEntityTypeConfiguration<Devis>
    {
        public void Configure(EntityTypeBuilder<Devis> builder)
        {
            builder.Property(x => x.Prix).HasColumnType("decimal(18,2)");
            builder.HasOne(b => b.Grossiste).WithMany().HasForeignKey(f => f.GrossisteId);

        }
    }
}
