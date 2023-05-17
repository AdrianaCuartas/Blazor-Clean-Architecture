namespace BlazingPizza.Backend.BusinessObjects.Interfaces.GetToppings;
public interface IGetToppingsInputPort
{
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();
}
