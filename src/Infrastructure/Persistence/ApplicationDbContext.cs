using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Tsql
{
    public sealed class ApplicationDbContext 
        : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;


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

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
           //modelBuilder.ApplyConfiguration(new ContactTableConfiguration());
           // modelBuilder.ApplyConfiguration(new OfferTableConfiguration());
        }                
        */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning
            optionsBuilder.UseSqlServer();
//            }            
        }
       
    }
}