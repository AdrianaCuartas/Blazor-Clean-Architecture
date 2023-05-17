namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.OrderDetails
{
    ////frontend-2 el modelo para el detalle de la orden

    public interface IOrderDetailsModel
    {

        Task<GetOrderDto> GetOrderAsync(int id);
    }
}
