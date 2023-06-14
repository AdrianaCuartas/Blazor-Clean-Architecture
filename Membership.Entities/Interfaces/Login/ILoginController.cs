namespace Membership.Entities.Interfaces.Login;

public interface ILoginController
{
    Task<UserTokensDto> LoginAsync(LocalUserCredentialsDto userCredentials);
}
