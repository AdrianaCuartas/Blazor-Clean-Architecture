namespace Membership.Blazor.Entities.Interfaces;

public interface IUserWebApiGateway
{
    Task RegisterUserAsync(UserForRegistrationDto userData);

    Task<UserTokensDto> LoginAsync(LocalUserCredentialsDto userCredentials);

    Task<UserTokensDto> RefreshTokenAsync(UserTokensDto userTokens);

    Task LogoutAsync(string refreshToken);

}
