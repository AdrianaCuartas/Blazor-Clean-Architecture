
namespace Membership.Entities.Interfaces.Login.RefreshToken;

public interface IRefreshTokenInputPort
{

    Task RefreshTokenAsync(UserTokensDto userDto);
}
