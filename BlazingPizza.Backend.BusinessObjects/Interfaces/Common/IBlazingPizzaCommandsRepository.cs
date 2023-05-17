namespace BlazingPizza.Backend.BusinessObjects.Interfaces.Common;
public interface IBlazingPizzaCommandsRepository
{
    Task<int> PlaceOrderAsync(PlaceOrderOrderDto order);
}
