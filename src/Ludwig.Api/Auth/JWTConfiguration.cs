using System.Globalization;

namespace Ludwig.Api.Auth;

public record JwtConfiguration
{
    public string Secret { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int ExpireDays { get; set; } = 7;

    public JwtConfiguration(IConfiguration configuration)
    {
        var section = configuration.GetSection("JWT");

        Issuer = section[nameof(Issuer)];
        Secret = section[nameof(Secret)];
        Audience = section[nameof(Secret)];
        ExpireDays = Convert.ToInt32(section[nameof(ExpireDays)], CultureInfo.InvariantCulture);
    }
}

