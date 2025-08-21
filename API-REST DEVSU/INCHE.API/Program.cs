using INCHE.Api;
using INCHE.Application;
using INCHE.Common;
using INCHE.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddPersistence(builder.Configuration);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins(
                "http://localhost:4200"   // Angular
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials() // si necesitas enviar cookies/jwt por headers
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowFrontend");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    c.RoutePrefix = "swagger"; // UI en /swagger
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
