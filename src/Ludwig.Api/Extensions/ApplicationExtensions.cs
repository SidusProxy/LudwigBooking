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
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>{
        options.TokenValidationParameters = new TokenValidationParameters{
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["TokenHandler:iss"],
            ValidAudience = builder.Configuration["TokenHandler:aud"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key"))
        };
    });

        builder.Services.AddAuthorization();

    }




}

