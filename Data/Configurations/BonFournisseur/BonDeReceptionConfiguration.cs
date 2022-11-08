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
    internal class BonDeReceptionConfiguration : IEntityTypeConfiguration<BonDeReceptionFournisseur>
    {
        public void Configure(EntityTypeBuilder<BonDeReceptionFournisseur> builder)
        {
           
            builder.HasOne(b => b.Grossiste).WithMany().HasForeignKey(f => f.GrossisteId);
            builder.HasOne(b => b.FactureFournisseur).WithOne(a => a.BonDeReceptionFournisseur).HasForeignKey<FactureFournisseur>(b => b.BonDeReceptionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
