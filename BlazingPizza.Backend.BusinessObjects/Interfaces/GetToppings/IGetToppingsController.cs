namespace BlazingPizza.Backend.BusinessObjects.Interfaces.GetToppings;
public interface IGetToppingsController
{
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();
}
