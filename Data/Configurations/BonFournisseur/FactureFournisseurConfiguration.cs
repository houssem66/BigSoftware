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
    internal class FactureFournisseurConfiguration : IEntityTypeConfiguration<FactureFournisseur>
    {
        public void Configure(EntityTypeBuilder<FactureFournisseur> builder)
        {

        }
    }
}
