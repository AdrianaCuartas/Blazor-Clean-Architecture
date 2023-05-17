
namespace BlazingPizza.Desktop.Models;

public class DesktopConfigurePizzaDialogModel : IConfigurePizzaDialogModel
{
    readonly IGetToppingsController Controller;

    public DesktopConfigurePizzaDialogModel(IGetToppingsController controller)
    {
        Controller = controller;
    }

    public Task<IReadOnlyCollection<Topping>> GetToppingsAsync()
    {
        return Controller.GetToppingsAsync();
    }
}
