using Microsoft.OpenApi.Models;
using Services.Abstractions;
using Domain.Services;

var webApplication = WebApplication.CreateBuilder(args);

// Add services to the container
webApplication.Services.AddControllers()
                       .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
webApplication.Services.AddScoped<IServiceManager, ServiceManager>();

// Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
webApplication.Services.AddEndpointsApiExplorer();
var swaggerDocName = "antigaspiApi";
var swaggerInfo = new OpenApiInfo
{
    Title = "antigaspiApi",
     Version = "1.0.0"
};

webApplication.Services.AddSwaggerGen(
        swagger => swagger.SwaggerDoc(swaggerDocName, swaggerInfo ));

var app = webApplication.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
