namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.Checkout;
public interface ICheckoutModel
{
    Task<int> PlaceOrderAsync(Order order);
}
