using System.Reflection;
using SolarLab.EBoard.Application;
using SolarLab.EBoard.Infrastructure;
using SolarLab.EBoard.WebApi;
using SolarLab.EBoard.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

var apiGroup = app.MapGroup("/api");
app.MapEndpoints(apiGroup);
    
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MigrateDb();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();