namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.ConfigurePizzaDialog;
public interface IConfigurePizzaDialogModel
{
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();
}
