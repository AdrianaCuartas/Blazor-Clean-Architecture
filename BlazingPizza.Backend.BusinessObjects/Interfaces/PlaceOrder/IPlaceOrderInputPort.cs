namespace BlazingPizza.Backend.BusinessObjects.Interfaces.PlaceOrder;
public interface IPlaceOrderInputPort
{
    Task<int> PlaceOrderAsync(PlaceOrderOrderDto order);
}
