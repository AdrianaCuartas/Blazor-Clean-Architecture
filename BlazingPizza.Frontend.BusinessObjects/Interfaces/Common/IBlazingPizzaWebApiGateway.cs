namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.Common;

//frontend-1
public interface IBlazingPizzaWebApiGateway
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();

    Task<int> PlaceOrderAsync(Order order);
    Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync();

    Task<GetOrderDto> GetOrderAsync(int id);
}



