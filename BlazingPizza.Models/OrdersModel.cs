
namespace BlazingPizza.Models;
internal sealed class OrdersModel : IOrdersModel
{
    readonly IBlazingPizzaWebApiGateway Gateway;

    public OrdersModel(IBlazingPizzaWebApiGateway gateway)
    {
        Gateway = gateway;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        return await Gateway.GetOrdersAsync();


        //para probar que no hay ordenes, para que salga un mensaje
        return await Task.FromResult(new List<GetOrdersDto>());
    }
}
