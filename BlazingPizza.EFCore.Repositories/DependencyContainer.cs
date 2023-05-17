
namespace BlazingPizza.EFCore.Repositories;
public static class DependencyContainer
{
    public static IServiceCollection AddRepositoriesServices(
        this IServiceCollection services
        )
    {
        //Se cambio por la refactorización del patron Options.
        //services.AddDbContext<BlazingPizzaContext>(options =>
        //options.UseSqlServer(connectionString));


        //el servicio AddDbContext es scope 
        services.AddDbContext<IBlazingPizzaQueriesContext, BlazingPizzaQueriesContext>();

        services.AddDbContext<IBlazingPizzaCommandsContext, BlazingPizzaCommandsContext>();

        services.AddScoped<IBlazingPizzaQueriesRepository,
            BlazingPizzaQueriesRepository>();

        services.AddScoped<IBlazingPizzaCommandsRepository,
            BlazingPizzaCommandsRepository>();

        return services;
    }
}
