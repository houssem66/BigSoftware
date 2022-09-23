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
    internal class BonDeReceptionConfiguration : IEntityTypeConfiguration<BonDeReceptionFournisseur>
    {
        public void Configure(EntityTypeBuilder<BonDeReceptionFournisseur> builder)
        {
            builder.Property(x => x.Prix).HasColumnType("decimal(18,2)");
        }
    }
}
