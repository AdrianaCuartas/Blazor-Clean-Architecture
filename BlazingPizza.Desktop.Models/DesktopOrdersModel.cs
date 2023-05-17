
namespace BlazingPizza.Desktop.Models;

public class DesktopOrdersModel : IOrdersModel
{
    readonly IGetOrdersController Controller;

    public DesktopOrdersModel(IGetOrdersController controller)
    {
        Controller = controller;
    }

    public Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        return Controller.GetOrdersAsync();
    }
}
