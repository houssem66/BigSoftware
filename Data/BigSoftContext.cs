using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class BigSoftContext :  IdentityDbContext<Utilisateur>
    {
        public BigSoftContext(DbContextOptions<BigSoftContext> options) : base(options)
        {

        }
       //Dbset
       //Sprint1
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Grossiste> Grossistes { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Document> Documents { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {//Sprint 1
            base.OnModelCreating(builder);
            builder.Entity<Grossiste>().HasMany(d => d.Documents).WithOne(u => u.Grossiste).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
