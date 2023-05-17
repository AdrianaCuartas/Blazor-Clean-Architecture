
namespace Membership.Entities.Interfaces.Login.RefreshToken;

public interface IRefreshTokenController
{
    Task<UserTokensDto> RefreshTokenAsync(UserTokensDto userTokens);
}
