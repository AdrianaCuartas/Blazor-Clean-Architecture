namespace BlazingPizza.Backend.BusinessObjects.Interfaces.GetOrder;
public interface IGetOrderInputPort
{
    Task<GetOrderDto> GetOrderAsync(int id);
}
