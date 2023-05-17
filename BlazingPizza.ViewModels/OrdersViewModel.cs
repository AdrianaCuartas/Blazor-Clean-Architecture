
namespace BlazingPizza.ViewModels;
internal sealed class OrdersViewModel : IOrdersViewModel
{
    readonly IOrdersModel Model;

    public OrdersViewModel(IOrdersModel model)
    {
        Model = model;
    }

    public IReadOnlyCollection<GetOrdersDto> Orders
    { get; private set; }

    public async Task GetOrdersAsync()
    {
        Orders = await Model.GetOrdersAsync();
    }
}
