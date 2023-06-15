namespace Membership.Controllers;
internal class RegisterController : IRegisterController
{
    readonly IRegisterInputPort Inputport;

    public RegisterController(IRegisterInputPort inputport)
    {
        Inputport = inputport;
    }

    public Task RegisterAsync(Shared.Entities.UserForRegistrationDto userData) =>
        Inputport.RegisterAsync(userData);

}
