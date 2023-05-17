namespace BlazingPizza.Backend.BusinessObjects.Interfaces.Common;
public interface IBlazingPizzaQueriesRepository
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();
    //solo debe retornar las ordenes de un usuario autenticado
    Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync(string userId);

    //solo se puede ver el detalle de la orden del usuario que realizo dicha Orden
    Task<GetOrderDto> GetOrderAsync(int id, string userId);
}
