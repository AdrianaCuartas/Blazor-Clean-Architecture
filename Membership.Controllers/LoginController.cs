namespace Membership.Controllers;
internal class LoginController : ILoginController
{
    readonly ILoginInputPort InputPort;
    readonly ILoginPresenter Presenter;

    public LoginController(ILoginInputPort inputPort, ILoginPresenter presenter)
    {
        InputPort = inputPort;
        Presenter = presenter;
    }

    public async Task<UserTokensDto> LoginAsync(UserCredentialsDto userCredentials)
    {
        await InputPort.LoginAsync(userCredentials);
        return Presenter.UserTokens;
    }
}
