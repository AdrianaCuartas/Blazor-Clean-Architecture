namespace BlazingPizza.ViewModels;
internal sealed class ConfigurePizzaDialogViewModel : IConfigurePizzaDialogViewModel
{
    readonly IConfigurePizzaDialogModel Model;

    public ConfigurePizzaDialogViewModel(IConfigurePizzaDialogModel model)
    {
        Model = model;
    }

    public Pizza Pizza { get; set; }

    IReadOnlyCollection<Topping> ToppingsField;
    public IReadOnlyCollection<Topping> Toppings
    {
        get
        {
            return ToppingsField?.OrderBy(t => t.Name).ToList();
        }

        private set
        {
            ToppingsField = value;
        }
    }

    public void AddTopping(Topping topping) =>
        Pizza.AddTopping(topping);

    public async Task GetToppingsAsync()
    {
        if (Toppings == null)
        {
            Toppings = await Model.GetToppingsAsync();
        }
    }

    public void RemoveTopping(Topping topping) =>
        Pizza.RemoveTopping(topping);

    public int ConfiguredPizzaSize
    {
        get => Pizza.Size;
        set => Pizza.SetSize(value);
    }
}
