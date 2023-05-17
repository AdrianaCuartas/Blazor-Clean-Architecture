namespace Membership.Entities.Interfaces.Logout;

public interface ILogoutInputPort
{
    Task LogoutAsync(string refreshToken);
}
