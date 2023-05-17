using Membership.Entities.Dtos;
using Membership.Entities.Interfaces;
using Membership.Entities.Interfaces.Register;

namespace Membership.UserManager.Register;

internal class RegisterInteractor : IRegisterInputPort
{
    readonly IUserManagerService UserManagerService;

    public RegisterInteractor(IUserManagerService userManagerService)
    {
        UserManagerService = userManagerService;
    }

    public async Task RegisterAsync(UserForRegistrationDto userData)
    {
        await UserManagerService.ThrowIfUnableToRegisterAsync(userData);
    }
}
