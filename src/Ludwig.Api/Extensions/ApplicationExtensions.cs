using JwtAuthApp.JWT;
using Ludwig.Api.Auth;
using Ludwig.Api.Exceptions;
using Ludwig.Data.Interfaces;
using Ludwig.Data.Models;
using Ludwig.Data.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace Ludwig.Api.Extensions;

public static class ApplicationExtensions
{
    public static void ConfigureSystemServices(this WebApplicationBuilder builder, string MyAllowSpecificOrigins)
    {

        builder.Services.AddCors(options =>{ options.AddPolicy(name: MyAllowSpecificOrigins, policy =>{policy.WithOrigins("https://localhost:7096"); });});

        builder.Services.AddDbContext<BookingSystemContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("BookingLudwigContext")));

        builder.Services.AddScoped<IDatiPrenotazione, ServizioDatiPrenotazione>();
        builder.Services.AddScoped<IDatiUtenti, ServizioDatiUtenti>();
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddTransient<JwtConfiguration>();
        builder.Services.AddJwtAuthentication(builder.Configuration);
        builder.Services.AddTransient<TokenService>();
        builder.Services.AddTransient<AppUser>();
        builder.Services.AddHttpContextAccessor();

    }




}

