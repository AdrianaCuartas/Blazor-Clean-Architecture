

namespace BlazingPizza.EFCore.Repositories.DataContexts;
internal sealed class BlazingPizzaCommandsContext : BlazingPizzaContext,
    IBlazingPizzaCommandsContext
{
    public BlazingPizzaCommandsContext(IOptions<ConnectionStringsOptions>
        connectionStringOptions) : base(connectionStringOptions)
    {
    }

    public Task<int> SaveChangesAsync() => base.SaveChangesAsync();

}
