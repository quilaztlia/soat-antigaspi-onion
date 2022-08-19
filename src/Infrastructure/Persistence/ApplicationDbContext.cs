using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Tsql
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {
        }

        public DbSet<Contact> Contacts { get; set; } = default!;

        //CHECK: default express to Observe Behaviour
        public DbSet<Offer> Offers { get; set; } = default;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }        
    }

}