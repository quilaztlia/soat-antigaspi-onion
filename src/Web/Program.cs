using Antigaspi.Web.Middleware;
using Domain.Repository.Abstractions;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
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

            //webApplication.Services.AddAWSService<IAmazonDynamoDB>();

            // Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            webApplication.Services.AddEndpointsApiExplorer();

            var swaggerDocName = "Antigaspi.Web";
            var swaggerInfo = new OpenApiInfo
            {
                Title = "swaggerDocName",
                Version = "1.0.0"
            };
            webApplication.Services.AddSwaggerGen(
                    swagger => swagger.SwaggerDoc("v1", swaggerInfo));

            var app = webApplication.Build();

            //CHECK : If working           
            await ApplyMigrations(app.Services);

            //CHECK : ExceptionHandlerMiddleware ??
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

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