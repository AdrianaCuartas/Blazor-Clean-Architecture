namespace Membership.Controllers;
internal class RegisterController : IRegisterController
{
    readonly IRegisterInputPort Inputport;

    public RegisterController(IRegisterInputPort inputport)
    {
        Inputport = inputport;
    }

    public Task RegisterAsync(LocalUserForRegistrationDto userData) =>
        Inputport.RegisterAsync(userData);

}
