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
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            
            builder.HasMany(e=>e.FactureClients).WithOne(e=>e.Client).HasForeignKey(e=>e.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e=>e.Devis).WithOne(e=>e.Client).HasForeignKey(e=>e.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e=>e.BonCommandeClients).WithOne(e=>e.Client).HasForeignKey(e=>e.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e=>e.BonLivraisonClients).WithOne(e=>e.Client).HasForeignKey(e=>e.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e=>e.BonSorties).WithOne(e=>e.Client).HasForeignKey(e=>e.ClientId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
