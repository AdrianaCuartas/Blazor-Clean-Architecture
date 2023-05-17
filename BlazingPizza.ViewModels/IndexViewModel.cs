
namespace BlazingPizza.ViewModels;
internal sealed class IndexViewModel : IIndexViewModel
{
    readonly IOrderStateService OrderStateService;
    public IndexViewModel(IOrderStateService orderStateService) =>
        OrderStateService = orderStateService;

    public Pizza ConfiguringPizza { get; set; }
    public bool ShowingConfigureDialog { get; set; }

    public void CancelConfigurePizzaDialog()
    {
        ResetPizza();
    }

    public void ConfirmConfigurePizzaDialog()
    {
        OrderStateService.Order.AddPizza(ConfiguringPizza);

        ResetPizza();
    }

    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new Pizza(special);
        ShowingConfigureDialog = true;
    }

    void ResetPizza()
    {
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;
    }
}
