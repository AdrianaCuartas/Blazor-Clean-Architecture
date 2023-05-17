namespace Membership.Entities.Interfaces.Login;

public interface ILoginPresenter
{
    UserTokensDto UserTokens { get; }
    Task HandleUserDataAsync(UserDto userData);


}
