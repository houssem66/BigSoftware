using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class BigSoftContext : DbContext
    {
        public BigSoftContext(DbContextOptions<BigSoftContext> options) : base(options)
        {

        }
       //Dbset
       //Sprint1
        public DbSet<Utilisateur> User { get; set; }
        public DbSet<Grossiste> Grossistes { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Client> Clients { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
