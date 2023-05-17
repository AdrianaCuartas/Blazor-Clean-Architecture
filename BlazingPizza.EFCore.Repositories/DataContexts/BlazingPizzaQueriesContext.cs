
namespace BlazingPizza.EFCore.Repositories.DataContexts;

internal sealed class BlazingPizzaQueriesContext : BlazingPizzaContext,
    IBlazingPizzaQueriesContext
{
    public BlazingPizzaQueriesContext(IOptions<ConnectionStringsOptions>
        connectionStringOptions) : base(connectionStringOptions)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    }

}
