namespace Membership.Presenters;

internal class RefreshTokenPresenter : IRefreshTokenPresenter
{
    readonly JwtConfigurationOptions Options;
    readonly IRefreshTokenManager RefreshTokenManager;

    public RefreshTokenPresenter(IOptions<JwtConfigurationOptions> options,
        IRefreshTokenManager refreshManager)
    {
        Options = options.Value;
        RefreshTokenManager = refreshManager;
    }

    public UserTokensDto UserTokens { get; private set; }

    public async Task GenerateTokenAsync(string oldaccessToken)
    {
        List<Claim> UserClaims = JwtHelper.GetUserClaimsFromToken(oldaccessToken);
        string AccessToken = JwtHelper.GetAccessToken(Options, UserClaims);
        string RefreshToken = await RefreshTokenManager.GetNewTokenAsync(AccessToken);
        UserTokens = new UserTokensDto
        {
            Refresh_Token = RefreshToken,
            Acess_Token = AccessToken
        };

    }
}
