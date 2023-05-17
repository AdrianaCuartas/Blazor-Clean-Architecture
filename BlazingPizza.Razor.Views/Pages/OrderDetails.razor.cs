

namespace BlazingPizza.Razor.Views.Pages;

public partial class OrderDetails
{
    [Inject]
    IOrderDetailsViewModel ViewModel { get; set; }

    [Parameter]
    public int OrderId { get; set; }


    OrderStatus OrderStatus;
    protected async override Task OnParametersSetAsync()
    {
        await ViewModel.GetOrderAsync(OrderId);
        OrderStatus = ViewModel.Order.Status;
    }

    void OnNotificationReceived(OrderStatusNotification notification)
    {
        OrderStatus = notification.OrderStatus;

    }
}
