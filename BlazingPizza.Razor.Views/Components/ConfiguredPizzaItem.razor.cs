using SweetAlert.Blazor;

namespace BlazingPizza.Razor.Views.Components;
public partial class ConfiguredPizzaItem
{

    [Parameter]
    public Pizza Pizza { get; set; }

    [Parameter]
    public EventCallback OnRemoved { get; set; }

    [Inject] public SweetAlertService SweetAlertService { get; set; }

    //se crea un metodo intermediario para preguntar si se desea eliminar la pizza
    async Task RemovePizaConfirmation()
    {
        var MessageParameters = new ConfirmArgs(
            "¿Eliminar la pizza?",
            $"¿Eliminar la pizza{Pizza.Special.Name} de la orden?",
            Icon.Warning,
            "No, quiero dejarlo en mi orden",
            "Si, eliminar la pizza",
            true);

        bool Remove =
             await SweetAlertService.ConfirmAsync(MessageParameters);

        if (Remove)
        {
            await OnRemoved.InvokeAsync();
        }

    }

}
