using GoldenBanana.Api.Dtos;
using GoldenBanana.Api.Infrastructure;
using GoldenBanana.Api.Infrastructure.Interfaces;
using GoldenBanana.Api.Infrastructure.Repositories;
using GoldenBanana.Api.Interfaces;
using GoldenBanana.Api.Services;

using Microsoft.AspNetCore.Identity;
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

// Identity settings
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IHideoutService, HideoutService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IHideoutRepository, HideoutRepository>();
builder.Services.AddScoped<IHideoutMapRepository, HideoutMapRepository>();
builder.Services.AddScoped<IHideoutTagRepository, HideoutTagRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// More Identity settings
//builder.Services.Configure<IdentityOptions>(options =>
//{
//    // password settings
//    options.Password.RequireDigit = false;
//    options.Password.RequireLowercase = false;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireUppercase = false;
//    options.Password.RequiredLength = 8;
//    options.Password.RequiredUniqueChars = 1;

//    // lockout settings
//    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//    options.Lockout.MaxFailedAccessAttempts = 5;
//    options.Lockout.AllowedForNewUsers = true;

//    // user settings
//    options.User.AllowedUserNameCharacters =
//        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._+!?#";
//    options.User.RequireUniqueEmail = true;
//});

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    // Cookie settings
//    options.Cookie.HttpOnly = true;
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
//    options.SlidingExpiration = true;
//});


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
