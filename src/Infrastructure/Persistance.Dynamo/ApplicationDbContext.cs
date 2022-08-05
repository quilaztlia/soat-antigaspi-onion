using Domain.Entities;
//using Microsoft.EntityFrameworkCore;

namespace Persistence.Dynamo
{
    public class ApplicationDbContext : DbContext
    {
        /*
        public RepositoryDbContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
        }        
        */
    }

}