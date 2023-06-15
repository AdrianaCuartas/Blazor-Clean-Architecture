namespace Membership.UserManager.Register;

internal class RegisterInteractor : IRegisterInputPort
{
    readonly IUserManagerService UserManagerService;

    public RegisterInteractor(IUserManagerService userManagerService)
    {
        UserManagerService = userManagerService;
    }

    public async Task RegisterAsync(Shared.Entities.UserForRegistrationDto userData)
    {

        await UserManagerService.ThrowIfUnableToRegisterAsync(
            new UserForRegistrationDto
            {
                UserName = userData.UserName,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                Password = userData.Password
            });
    }
}
