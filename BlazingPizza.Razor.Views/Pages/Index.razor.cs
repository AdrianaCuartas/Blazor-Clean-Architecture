namespace BlazingPizza.Razor.Views.Pages;
public partial class Index
{
    [Inject]
    public IIndexViewModel ViewModel { get; set; }

    [Inject]
    public IOrderStateService OrderStateService { get; set; }

    protected override void OnParametersSet()
    {
        ViewModel.ShowingConfigureDialog = false;
    }

}
