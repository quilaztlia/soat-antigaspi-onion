using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Tsql
{
    public sealed class ApplicationDbContext 
        : DbContext
    {
        public ApplicationDbContext()
            : base()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {            
        }

        public DbSet<Contact> Contacts { get; set; } = default!;

        //CHECK: default express to Observe Behaviour
        public DbSet<Offer> Offers { get; set; } = default;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
           //modelBuilder.ApplyConfiguration(new ContactTableConfiguration());          
        }                        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer();       
        }
       
    }
}