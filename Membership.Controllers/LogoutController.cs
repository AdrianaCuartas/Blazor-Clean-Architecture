using Membership.Entities.Interfaces.Logout;

namespace Membership.Controllers;

internal class LogoutController : ILogoutController
{
    readonly ILogoutInputPort Inputport;

    public LogoutController(ILogoutInputPort inputport)
    {
        Inputport = inputport;
    }

    public async Task LogoutAsync(string refreshToken)
    {
        await Inputport.LogoutAsync(refreshToken);

    }
}
