

namespace BlazingPizza.Models;
//frontend-6 
internal sealed class OrderDetailsModel : IOrderDetailsModel
{

    readonly IBlazingPizzaWebApiGateway Gateway;

    public OrderDetailsModel(IBlazingPizzaWebApiGateway gateway)
    {
        Gateway = gateway;
    }

    public async Task<GetOrderDto> GetOrderAsync(int id) =>
        await Gateway.GetOrderAsync(id);
}
