namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.ConfigurePizzaDialog;
public interface IConfigurePizzaDialogViewModel
{
    Pizza Pizza { get; set; }
    IReadOnlyCollection<Topping> Toppings { get; }

    Task GetToppingsAsync();
    void AddTopping(Topping topping);
    void RemoveTopping(Topping topping);

    int ConfiguredPizzaSize { get; set; }
}
