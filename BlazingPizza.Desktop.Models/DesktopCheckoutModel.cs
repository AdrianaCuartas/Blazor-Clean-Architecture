namespace BlazingPizza.Desktop.Models;

public class DesktopCheckoutModel : ICheckoutModel
{
    readonly IPlaceOrderController Controller;

    public DesktopCheckoutModel(IPlaceOrderController controller)
    {
        Controller = controller;
    }

    public Task<int> PlaceOrderAsync(Order order)
    {
        PlaceOrderOrderDto orderDto = (PlaceOrderOrderDto)order;

        return Controller.PlaceOrderAsync(orderDto);
    }
}
