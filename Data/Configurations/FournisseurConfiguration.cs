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
    internal class FournisseurConfiguration : IEntityTypeConfiguration<Fournisseur>
    {
        public void Configure(EntityTypeBuilder<Fournisseur> builder)
        {         

            builder.HasOne(b => b.Grossiste).WithMany().HasForeignKey(f=>f.IdGrossiste);
            builder.HasMany(b => b.BonDeCommandes).WithOne(b => b.Fournisseur).HasForeignKey(f=>f.FournisseurId).OnDelete(DeleteBehavior.Cascade);
           
        }
    }
}
