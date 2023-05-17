
namespace BlazingPizza.OrderTrackerSimulator;

public class OrdertStatusNotificatorSimulator : IOrderStatusNotificator, IDisposable
{

    #region Constantes
    const int PreparationTime = 10;
    const double SpeedKmXHr = 100.0;
    const double DistanceKm = 2.5;
    const double NotificationInvervalInSeconds = 2.5;
    #endregion

    readonly GoToDestinationSimulator Simulator = new();
    readonly Dictionary<int, Action<OrderStatusNotification>> TrackedOrders = new();


    public async Task<LatLong> SubscribeAsync(GetOrderDto order, Action<OrderStatusNotification> callBack)
    {
        TrackedOrders.TryAdd(order.Id, callBack);
        RouteInfo RouteInfo = new RouteInfo(order.Id, new PositionTrackerLatLong(order.DeliveryLocation.Latitude,
            order.DeliveryLocation.Longitude), order.CreatedTime.AddSeconds(PreparationTime),
            SpeedKmXHr, DistanceKm, NotificationInvervalInSeconds, OnChangePosition);
        var Origin = await Simulator.SubscribeAsync(RouteInfo);

        return new LatLong(Origin.Latitude, Origin.Longitude);
    }

    void OnChangePosition(PositionNotification notification)
    {
        TrackedOrders[notification.RouteId].Invoke(new OrderStatusNotification
        (
             new LatLong(notification.CurrentPosition.Latitude, notification.CurrentPosition.Longitude),
             notification.CurrentDistanceInMeters,
             notification.CurrentDistanceInMeters == 0 ? OrderStatus.Preparing :
                notification.Finished ? OrderStatus.Delivered : OrderStatus.OutForDelivery

        ));
    }
    public void UnSubscribe(int orderId)
    {
        if (TrackedOrders.ContainsKey(orderId))
        {
            Simulator.UnSubscribe(orderId);
            TrackedOrders.Remove(orderId);
        }
    }
    public void Dispose()
    {
        foreach (var Order in TrackedOrders)
        {
            UnSubscribe(Order.Key);

        }
        TrackedOrders.Clear();
    }
}