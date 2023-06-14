namespace Membership.Blazor.WebApiGateway;

public class UserEndpointsOptions
{

    public const string SectionKey = "UserEndpoints";

    public string WeApiBaseAddress { get; set; }

    public string Resgister { get; set; }

    public string Login { get; set; }

    public string RefreshToken { get; set; }

    public string Logout { get; set; }
}
