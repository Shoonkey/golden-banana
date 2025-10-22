using GoldenBanana.Api.Dtos;
using GoldenBanana.Api.Infrastructure;
using GoldenBanana.Api.Infrastructure.Interfaces;
using GoldenBanana.Api.Infrastructure.Repositories;
using GoldenBanana.Api.Interfaces;
using GoldenBanana.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets<AppSettings>();

// Add services to the container.
var con = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<AppDbContext>(opt =>
    opt.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHideoutService, HideoutService>();
builder.Services.AddScoped<IHideoutRepository, HideoutRepository>();
builder.Services.AddScoped<IHideoutMapRepository, HideoutMapRepository>();
builder.Services.AddScoped<IHideoutTagRepository, HideoutTagRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
