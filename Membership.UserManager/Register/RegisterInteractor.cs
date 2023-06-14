using Membership.Entities.Dtos;

namespace Membership.UserManager.Register;

internal class RegisterInteractor : IRegisterInputPort
{
    readonly IUserManagerService UserManagerService;

    public RegisterInteractor(IUserManagerService userManagerService)
    {
        UserManagerService = userManagerService;
    }

    public async Task RegisterAsync(LocalUserForRegistrationDto userData)
    {

        await UserManagerService.ThrowIfUnableToRegisterAsync(
            new UserForRegistrationDto
            {
                UserName = userData.Email,
                Email = userData.Email,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                Password = userData.Password
            });
    }
}
