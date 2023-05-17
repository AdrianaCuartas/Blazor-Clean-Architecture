using Membership.Entities.Interfaces.Logout;

namespace Membership.UserManager.Logout;

internal class LogoutInteractor : ILogoutInputPort
{
    readonly IRefreshTokenManager Manager;

    public LogoutInteractor(IRefreshTokenManager manager)
    {
        Manager = manager;
    }

    public async Task LogoutAsync(string refreshToken)
    {
        await Manager.DeleteTokenAsync(refreshToken);
    }
}
