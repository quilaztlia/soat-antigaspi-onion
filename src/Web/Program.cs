using Antigaspi.Web.Extensions;
using Antigaspi.Web.Middleware;
using Domain.Repository.Abstractions;
using Domain.Services;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Persistence.Tsql;
using Services.Abstractions;

namespace Soat.Antigaspi.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webApplication = WebApplication.CreateBuilder(args);

            // Add services to the container
            webApplication.Services.AddTransient<CustomExceptionHandlerMiddleware>();

            webApplication.Services.AddControllers()
                                   .AddApplicationPart(typeof(Presentation.Rest.AssemblyReference).Assembly); ;

            webApplication.Services.AddScoped<IServiceManager, ServiceManager>();

            webApplication.Services.AddScoped<IRepositoryManager, RepositoryManager>();

            webApplication.Services.AddDbContextPool<ApplicationDbContext>(
                builder => {
                    var connectionString = webApplication.Configuration.GetConnectionString("AntigaspiDB");
                    builder.UseSqlServer(connectionString);
                });
            //webApplication.Services.AddAWSService<IAmazonDynamoDB>();
            
            // CHECK : Cors ExtensionMethod
            webApplication.Services.AddCors(
                options => 
                {
                    options.AddPolicy("CorsPolicy",
                            webAppBuilde => webAppBuilde.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());
                });

            // IISConfig in ExtensionMethod
            webApplication.Services.ConfigureIISIntegration();

            // Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            webApplication.Services.AddEndpointsApiExplorer();

            var swaggerDocName = "Antigaspi.Web";
            var swaggerInfo = new OpenApiInfo
            {
                Title = swaggerDocName,
                Version = "1.0.0"
            };
            webApplication.Services.AddSwaggerGen(
                    swagger => swagger.SwaggerDoc("v1", swaggerInfo));

//========================================================            
            var app = webApplication.Build();
                      
            //await ApplyMigrations(app.Services);
            
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            // CHECK Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // CHECK : wwwroot by Default
            //app.UseStaticFiles();

            // CHECK: Send Proxy headers to CurrentRequest
            app.UseForwardedHeaders( new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseCors(); //Before UseAuthorization

            // CHECK : 
            //app.UseAuthorization();
            //app.UseAuthentication();

            app.MapControllers(); //I find controllers

            app.Run();
        }

        // CHECK: EFTools, EF.SqlServer
        static async Task ApplyMigrations(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            await using ApplicationDbContext dbContext = scope
                .ServiceProvider
                .GetRequiredService<ApplicationDbContext>();

            await dbContext.Database.MigrateAsync();
        }
    }
}