namespace Membership.Controllers;

internal class ExternalRegisterController : IExternalRegisterController
{
    readonly IExternalRegisterInputPort InputPort;

    public ExternalRegisterController(IExternalRegisterInputPort inputPort)
    {
        InputPort = inputPort;
    }

    public Task RegisterAsync(ExternalUserForRegistrationDto userData) =>
     InputPort.RegisterAsync(userData);
}
