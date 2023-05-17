

using BlazingPizza.Shared.BusinessObjects.Enums;

namespace BlazingPizza.Frontend.BusinessObjects.ValueObjects;

public class OrderStatusNotification
{
    public LatLong CurrentPosition { get; set; } //ubicacion actual
    public double CurrentDistance { get; set; } //cuantos metros lleva recorrido
    public OrderStatus OrderStatus { get; set; } //status de la orden

    public OrderStatusNotification(LatLong currentPosition, double currentDistance, OrderStatus status)
    {
        CurrentPosition = currentPosition;
        CurrentDistance = currentDistance;
        OrderStatus = status;
    }
}
