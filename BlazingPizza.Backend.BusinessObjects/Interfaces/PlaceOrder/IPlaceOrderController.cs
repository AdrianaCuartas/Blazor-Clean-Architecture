namespace BlazingPizza.Backend.BusinessObjects.Interfaces.PlaceOrder;
public interface IPlaceOrderController
{
    Task<int> PlaceOrderAsync(PlaceOrderOrderDto order);
}
