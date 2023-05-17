namespace BlazingPizza.Presenters;
public static class DependencyContainer
{
    public static IServiceCollection AddPresentersServices(
        this IServiceCollection services)
    {
        //services.AddScoped<IGetSpecialsPresenter>(provider =>
        //new GetSpecialsPresenter(imagesBaseUrl));


        services.AddScoped<IGetSpecialsPresenter, GetSpecialsPresenter>();
        return services;
    }
}
