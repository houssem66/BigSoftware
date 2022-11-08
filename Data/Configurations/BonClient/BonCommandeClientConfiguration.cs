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
    internal class BonCommandeClientConfiguration : IEntityTypeConfiguration<BonCommandeClient>
    {
        public void Configure(EntityTypeBuilder<BonCommandeClient> builder)
        {
           
            builder.HasOne(b => b.Grossiste).WithMany().HasForeignKey(f => f.GrossisteId);
        }
    }
}
