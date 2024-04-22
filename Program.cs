using Microsoft.EntityFrameworkCore;
using RaidControllerApi;
using RaidControllerApi.Interfaces.Repositories;
using RaidControllerApi.Interfaces.Services;
using RaidControllerApi.Repositories;
using RaidControllerApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


#region Custom Services
builder.Services.AddScoped<IPlayerService, PlayerService>();
    builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

    builder.Services.AddScoped<IRaidRepository, RaidRepository>();
    builder.Services.AddScoped<IRaidService, RaidService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
