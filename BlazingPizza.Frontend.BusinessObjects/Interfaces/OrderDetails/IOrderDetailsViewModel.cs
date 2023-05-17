namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.OrderDetails
{
    //frontend-3 el ViewModel para el detalle de la orden
    public interface IOrderDetailsViewModel
    {

        GetOrderDto Order { get; }
        bool InvalidOrder { get; }

        Task GetOrderAsync(int id);
    }
}
