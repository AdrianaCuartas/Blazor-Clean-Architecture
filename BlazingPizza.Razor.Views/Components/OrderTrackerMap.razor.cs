
namespace BlazingPizza.Razor.Views.Components;
//OrderTrackerMap debe recibir una notificacion de la posicion del repartidor
// y debe actualizar la posicion en el mapa para avisarle a su consumidor, y el consumidor
//debe mostrale al usuario el status.
public partial class OrderTrackerMap : IDisposable
{
    #region Servicios
    [Inject] IOrderStatusNotificator Notificator { get; set; }
    #endregion

    #region Parameters
    [Parameter] public byte ZoomLevel { get; set; } = 19;

    [Parameter] public GetOrderDto Order { get; set; }

    //el consumidor del tracker debe saber del status de la pizza
    //el tracker debe notificarle al consumidor
    [Parameter] public EventCallback<OrderStatusNotification> OnNotificationReceived { get; set; }
    #endregion

    #region Variables
    bool IsTracking;
    int DroneId;
    int TrackingOrderId = 0;
    #endregion

    #region Map
    Map Map;
    async Task OnCreateMapAsync(Map map)
    {
        Map = map;
        //cuando se crea el mapa y no esta realizando tracking: Empieza el tracking

        await TryStartTraking(Order);

    }
    #endregion

    //Overrides
    protected async override Task OnParametersSetAsync()
    {
        //cuado ya esta listo los parametros y no esta realizando tracking: Empieza el tracking
        await TryStartTraking(Order);
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await TryStartTraking(Order);
        }


    }
    #region metodos

    //refactoriza en el  video 12 0:28, y 1:15
    async Task TryStartTraking(GetOrderDto order)
    {
        if (Map != null)
        {
            if (!IsTracking)
            {
                await StartTracking(Order);
            }
            else
            {
                //se esta haciendo seguimiento a una orden que ya tiene tracking
                //con esto se puede pasar la misma orden de preparacion, en camino, entrgega
                if (Order.Id != TrackingOrderId)
                {
                    Notificator.UnSubscribe(TrackingOrderId);
                    await StartTracking(Order);
                }

            }
        }
    }
    //para hacer el rastreo de una orden 
    async Task StartTracking(GetOrderDto order)
    {

        IsTracking = true;
        TrackingOrderId = order.Id;
        DroneId = -1;
        await Map.RemoveMarkersAsync();//quita las marcas anteriores
        await Map.SetViewMapAsync(FromLatLong(order.DeliveryLocation)); //establece el viewmap en el punto del destino

        //obtiene el origen de lo que regresa el suscriptor y se suscribe al notificador  sobre una orden y cuando tengas informacion
        //notifica en el metodo OnMove
        var Origin = await Notificator.SubscribeAsync(order, OnMove);

        //agregar la marca de la tienda
        await Map.AddMarkerAsync(FromLatLong(Origin), "Pizza Store", "Blazing Pizza Store"); //"pizzastore"

        await Map.AddMarkerAsync(FromLatLong(order.DeliveryLocation), "Usted", "Lugar de entrega"); // "destination"

    }

    //es el metodo al cual se le avisa: para actualizar el drone y avise a quien este consumiendo:
    async void OnMove(OrderStatusNotification notification)
    {
        if (DroneId == -1) //si todavia no se ha pintado del dron
        {
            //refactoriza video 12  1:40
            //agrega la marca del dron en el origen
            DroneId = await Map.AddMarkerAsync(FromLatLong(notification.CurrentPosition), "Drón", "ubicación actual", "drone");
        }
        else
        {
            await Map.MoveMarkerAsync(DroneId, FromLatLong(notification.CurrentPosition));
        }

        await OnNotificationReceived.InvokeAsync(notification); //para que se entere quien esta consumiendo
        if (notification.OrderStatus == OrderStatus.Delivered)
        {
            IsTracking = false;
        }
    }

    LeafletLatLong FromLatLong(LatLong latLong) =>
        new LeafletLatLong(latLong.Latitude, latLong.Longitude);

    public void Dispose()
    {
        Notificator.UnSubscribe(Order.Id);
    }
    #endregion
}
