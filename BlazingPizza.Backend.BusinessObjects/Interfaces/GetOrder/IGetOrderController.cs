namespace BlazingPizza.Backend.BusinessObjects.Interfaces.GetOrder;
public interface IGetOrderController
{
    Task<GetOrderDto> GetOrderAsync(int id);
}
