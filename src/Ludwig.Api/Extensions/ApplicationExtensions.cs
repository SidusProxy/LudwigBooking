using Ludwig.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace Ludwig.Api.Extensions;

public static class ApplicationExtensions
{
    public static void ConfigureSystemServices(this WebApplicationBuilder builder, string MyAllowSpecificOrigins)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
                              {
                                  policy.WithOrigins("https://localhost:7096");
                              });
        });

        builder.Services.AddDbContext<BookingSystemContext>(
            options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BookingLudwigContext")));
        ;
    }




}

