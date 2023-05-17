
namespace BlazingPizza.Desktop.Models;

public class DesktopOrderDetailsModel : IOrderDetailsModel
{
    readonly IGetOrderController Controller;

    public DesktopOrderDetailsModel(IGetOrderController controller)
    {
        Controller = controller;
    }

    public async Task<GetOrderDto> GetOrderAsync(int id)
    {
        return await Controller.GetOrderAsync(id);
    }
}
