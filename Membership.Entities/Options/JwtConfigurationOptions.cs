namespace Membership.Entities.Options;

public class JwtConfigurationOptions
{
    public const string SectionKey = "Jwt";

    public string SecurityKey { get; set; }
    public string ValidIssuer { get; set; }
    public string ValidAudience { get; set; }
    public int ExpireInMinutes { get; set; }

    public int RefreshTokenExpireInMinutes { get; set; }
}