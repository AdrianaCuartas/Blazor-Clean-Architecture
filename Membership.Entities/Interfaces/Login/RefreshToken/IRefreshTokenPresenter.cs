

namespace Membership.Entities.Interfaces.Login.RefreshToken;

public interface IRefreshTokenPresenter
{
    UserTokensDto UserTokens { get; }

    Task GenerateTokenAsync(string oldaccessToken);
}
