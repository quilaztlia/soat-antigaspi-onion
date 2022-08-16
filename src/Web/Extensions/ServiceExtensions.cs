using Domain.Repository.Abstractions;
using LoggerService;
using LoggerService.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistence.Tsql;

namespace Antigaspi.Web.Extensions
{
    public static class ServiceExtensions
    {       
        public static void ConfigureCors(this IServiceCollection appServices)
        {
            appServices.AddCors(corsConfig =>
            {
                corsConfig.AddPolicy("CorsPolicy",
                        builder => builder
                            .AllowAnyOrigin() //WithOrigins("http://www.something.com")
                            .AllowAnyMethod() //WithMethods("POST", "GET")
                            .AllowAnyHeader()); //WithHeaders("accept", "content-type")
            });
        }        

        public static void ConfigureIISIntegration(this IServiceCollection appServices)
        {
            appServices.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLogger(this IServiceCollection appServices, ConfigurationManager configuration)
        {
            appServices.AddSingleton<ICustomLoggerManager, CustomLoggerManager>();
        }
    
        public static void ConfigureSqlContext(this IServiceCollection appServices, IConfiguration configuration)
        {
            appServices.AddDbContextPool<ApplicationDbContext>(
                builder => {
                    var connectionString = configuration.GetConnectionString("AntigaspiDB");
                    builder.UseSqlServer(connectionString);
                });
        }

        public static void ConfigureRepositoryManager(this IServiceCollection appServices)
        {
            appServices.AddScoped<IRepositoryManager, RepositoryManager>();         
        }
    }
}
