namespace Membership.Entities.Interfaces.Login;

public interface ILoginController
{
    Task<UserTokensDto> LoginAsync(UserCredentialsDto userCredentials);
}
