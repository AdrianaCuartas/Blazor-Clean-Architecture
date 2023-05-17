using CustomExceptions;

namespace BlazingPizza.EFCore.Repositories;
internal class BlazingPizzaCommandsRepository : IBlazingPizzaCommandsRepository
{
    readonly IBlazingPizzaCommandsContext Context;

    public BlazingPizzaCommandsRepository(IBlazingPizzaCommandsContext context)
    {
        Context = context;
    }

    public async Task<int> PlaceOrderAsync(PlaceOrderOrderDto order)
    {
        EFEntities.Order Order = order.ToEFOrder();

        //por ser autonumerico, no se debe asignar valor, esto 
        //va a generar una excepcion
        //Order.Id = 1;
        Context.Orders.Add(Order);
        try
        {
            await Context.SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new PersistenceException(ex.Message, ex.InnerException ?? ex);
        }

        return Order.Id;
    }
}
