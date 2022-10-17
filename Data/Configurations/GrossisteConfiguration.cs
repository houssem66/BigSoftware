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
    internal class GrossisteConfiguration: IEntityTypeConfiguration<Grossiste>
    {
      

        public void Configure(EntityTypeBuilder<Grossiste> builder)
        {
            builder.HasMany(d => d.Documents).WithOne(u => u.Grossiste).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(d => d.Stocks).WithOne(u => u.Grossiste).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
