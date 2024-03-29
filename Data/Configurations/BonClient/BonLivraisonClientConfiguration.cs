﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    internal class BonLivraisonClientConfiguration : IEntityTypeConfiguration<BonLivraisonClient>
    {
        public void Configure(EntityTypeBuilder<BonLivraisonClient> builder)
        {
           
            builder.HasOne(b => b.Grossiste).WithMany().HasForeignKey(f => f.GrossisteId);
            builder.HasOne(b => b.FactureClient).WithOne(x => x.BonLivraisonClient).HasForeignKey<FactureClient>(x => x.BonLivraisonId);

        }
    }
}
