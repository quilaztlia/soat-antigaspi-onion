using Antigaspi.Web.Middleware;
using Domain.Repository.Abstractions;
using Domain.Services;
using Microsoft.OpenApi.Models;
using Persistance.Dynamo;
using Services.Abstractions;

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
        swagger => swagger.SwaggerDoc("v1", swaggerInfo ));

var app = webApplication.Build();

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
