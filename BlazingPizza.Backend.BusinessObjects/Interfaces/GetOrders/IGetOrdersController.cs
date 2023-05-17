namespace BlazingPizza.Backend.BusinessObjects.Interfaces.GetOrders;
public interface IGetOrdersController
{
    Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync();
}
