
namespace GeolocationMap.Blazor;

//la funcion de este componente es mostrar un mapa donde se le permite
//al usuario que seleccione su ubicacion
public partial class GeolocationMap
{
    #region Servicios
    [Inject] GeolocationService Service { get; set; }


    [Inject] IGeocoder Geocoder { get; set; }
    #endregion

    #region Parámetros
    //para avisar al consumidor que se ha seleccionado una direccion
    [Parameter] public EventCallback<GeocodingAddress> OnSetPosition { get; set; }
    #endregion


    #region Variables
    int MarkerId;

    #endregion


    #region Map
    Map Map;

    async void OnCreatedMapAsync(Map map)
    {
        Map = map;
        await ShowLocation();
    }
    #endregion


    async Task ShowLocation()
    {
        var Position = await Service.GetPositionAsync();
        if (!Position.Equals(default(GeoLocationLatLong)))
        {
            var MapPosition = new LeafletLatLong(Position.Latitude, Position.Longitude);
            await Map.SetViewMapAsync(MapPosition);
            MarkerId = await Map.AddDraggableMarkerAsync(MapPosition, "Mi ubicación",
                ""); //destination
            await UpdateAddress(Position.Latitude, Position.Longitude);
        }
        else
        {
            Console.WriteLine("GeolocationMap: No se puede obtener la ubicación");
        }

    }

    async Task OnMarkerDragendAsync(DragendMarkerEventArgs e)
    {
        await UpdateAddress(e.Position.Latitude, e.Position.Longitude);

    }

    async Task UpdateAddress(double latitude, double longitude)
    {
        var Address = await Geocoder.GetGeocodingAddressAsync(latitude, longitude);

        string Message = $"{Address.DisplayAddress}<br/> Latitude: {latitude}<br/> Longitude: {longitude}";
        await Map.SetPopupMarkerContentAsync(MarkerId, Message);

        await OnSetPosition.InvokeAsync(Address);
    }
}
