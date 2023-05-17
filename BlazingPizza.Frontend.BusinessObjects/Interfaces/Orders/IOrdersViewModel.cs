namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.Orders;
public interface IOrdersViewModel
{
    IReadOnlyCollection<GetOrdersDto> Orders { get; }
    Task GetOrdersAsync();
}
