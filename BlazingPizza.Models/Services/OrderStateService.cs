namespace BlazingPizza.Models.Services;
internal sealed class OrderStateService : IOrderStateService
{
    public Order Order { get; private set; } = new Order();
    public void ReplaceOrder(Order order) => Order = order;
    public void ResetOrder() => Order = new Order();

}
