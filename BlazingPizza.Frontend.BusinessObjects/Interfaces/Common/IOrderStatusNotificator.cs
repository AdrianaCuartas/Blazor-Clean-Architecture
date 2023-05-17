


namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.Common;

public interface IOrderStatusNotificator
{
    //método para suscribirse, y retorna el punto de origen (donde esta la pizzeria).
    //va a retornar el origen de la pizza (tienda de la pizza)
    Task<LatLong> SubscribeAsync(GetOrderDto order, Action<OrderStatusNotification> callBack);
    void UnSubscribe(int orderId);

}