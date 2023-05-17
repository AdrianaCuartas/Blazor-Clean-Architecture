namespace Membership.Entities.Interfaces.Logout;

public interface ILogoutController
{
    Task LogoutAsync(string refreshToken);
}
