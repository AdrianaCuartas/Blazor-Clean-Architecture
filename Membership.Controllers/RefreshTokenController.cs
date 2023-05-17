namespace Membership.Controllers;
internal class RefreshTokenController : IRefreshTokenController
{
    readonly IRefreshTokenInputPort Inputport;
    readonly IRefreshTokenPresenter Presenter;

    public RefreshTokenController(IRefreshTokenInputPort inputport,
        IRefreshTokenPresenter presenter)
    {
        Inputport = inputport;
        Presenter = presenter;
    }

    public async Task<UserTokensDto> RefreshTokenAsync(UserTokensDto userTokens)
    {
        await Inputport.RefreshTokenAsync(userTokens);
        return Presenter.UserTokens;
    }
}
