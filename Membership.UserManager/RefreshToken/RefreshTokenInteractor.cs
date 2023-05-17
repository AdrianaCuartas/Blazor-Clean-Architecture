namespace Membership.UserManager.RefreshToken;

internal class RefreshTokenInteractor : IRefreshTokenInputPort
{
    readonly IRefreshTokenManager Manager;
    readonly IRefreshTokenPresenter Presenter;

    public RefreshTokenInteractor(IRefreshTokenManager manager,
        IRefreshTokenPresenter presenter)
    {
        Manager = manager;
        Presenter = presenter;
    }

    public async Task RefreshTokenAsync(UserTokensDto userDto)
    {
        await Manager.ThrowIfNotCanGetNewTokenAsync(userDto.Refresh_Token, userDto.Acess_Token);

        await Presenter.GenerateTokenAsync(userDto.Acess_Token);
    }
}
