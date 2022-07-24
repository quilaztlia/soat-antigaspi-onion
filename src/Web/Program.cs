using Microsoft.OpenApi.Models;
using Services.Abstractions;
using Domain.Services;
using Domain.Repository.Abstractions;
using Persistance.Dynamo;

var webApplication = WebApplication.CreateBuilder(args);

// Add services to the container
webApplication.Services.AddControllers()
                       .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

webApplication.Services.AddScoped<IServiceManager, ServiceManager>();

webApplication.Services.AddScoped<IRepositoryManager, RepositoryManager>();

//webApplication.Services.AddAWSService<IAmazonDynamoDB>();

//webApplication.Services.AddTransient<ExceptionHandlingMiddleware>();

// Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
webApplication.Services.AddEndpointsApiExplorer();

var swaggerDocName = "Antigaspi.Web";
var swaggerInfo = new OpenApiInfo
{
    Title = "swaggerDocName", 
     Version = "1.0.0"
};
webApplication.Services.AddSwaggerGen(
        swagger => swagger.SwaggerDoc("v1", swaggerInfo ));


var app = webApplication.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); //I find controllers

app.Run();
