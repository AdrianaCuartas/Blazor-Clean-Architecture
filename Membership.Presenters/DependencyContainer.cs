namespace Membership.Presenters;

public static class DependendencyContainer
{
    public static IServiceCollection AddMembershipPresenters(
        this IServiceCollection services)
    {
        services.AddScoped<ILoginPresenter, LoginPresenter>();
        services.AddScoped<IRefreshTokenPresenter, RefreshTokenPresenter>();
        return services;
    }
}