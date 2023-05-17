
namespace BlazingPizza.Models;
internal sealed class CheckoutModel : ICheckoutModel
{
    readonly IBlazingPizzaWebApiGateway Gateway;

    public CheckoutModel(IBlazingPizzaWebApiGateway gateway)
    {
        Gateway = gateway;
    }

    public async Task<int> PlaceOrderAsync(Order order)
    {
        return await Gateway.PlaceOrderAsync(order);
    }
}
