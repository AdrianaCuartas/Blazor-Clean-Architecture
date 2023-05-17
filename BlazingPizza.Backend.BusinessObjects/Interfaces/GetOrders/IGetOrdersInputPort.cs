namespace BlazingPizza.Backend.BusinessObjects.Interfaces.GetOrders;
public interface IGetOrdersInputPort
{
    Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync();
}
