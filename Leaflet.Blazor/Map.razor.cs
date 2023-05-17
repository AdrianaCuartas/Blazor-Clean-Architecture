using Microsoft.AspNetCore.Components;

namespace Leaflet.Blazor;
public sealed partial class Map : IAsyncDisposable
{
    #region inyeccion de servicios
    [Inject] LeafletService LeafletService { get; set; }
    #endregion

    #region Parametros
    [Parameter] public LeafletLatLong OriginalPoint { get; set; } = new LeafletLatLong(0, 0);
    //new LatLong(6.179537612507046, -75.5839476062311);

    [Parameter] public byte ZoomLevel { get; set; } = 1;

    // manejador de evento para notificar cuando esta cargado el mapa
    [Parameter] public EventCallback<Map> OnMapCreatedAsync { get; set; }

    //manejador de evento para notificale al consumidor la nueva ubicacion al arrastrar la marca
    [Parameter] public EventCallback<DragendMarkerEventArgs> OnMarkerDragendAsync { get; set; }
    #endregion

    #region variables
    string MapId = $"map-{Guid.NewGuid()}";
    bool IsMapReady = false;

    DotNetObjectReference<Map> MarkerHelper;
    #endregion

    #region Overrides
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await CreateMap(OriginalPoint, ZoomLevel);
        }
    }
    #endregion



    #region Methods publicos  
    public async Task CreateMap(LeafletLatLong point, byte zoomLevel = 14)
    {
        try
        {
            await LeafletService.InvokeVoidAsync("createMap", MapId, point, zoomLevel);
            IsMapReady = true;
            StateHasChanged();
            await OnMapCreatedAsync.InvokeAsync(this);
        }
        catch (Exception ex)
        {
            await Console.Out.WriteAsync(ex.ToString()); //2:10
        }


    }

    public async Task<int> AddMarkerAsync(LeafletLatLong point, string title,
        string description, string iconUrl = null)
    {

        return await LeafletService.InvokeAsync<int>("addMarker", MapId, point, title,
            description, BuildIconUrl(iconUrl));
    }

    //Video 13 1:46, Video 14 0:40
    public async Task<int> AddDraggableMarkerAsync(LeafletLatLong point, string title,
       string popupDescription, string iconUrl = null)
    {
        await SetDotNetObjectReference();

        return await LeafletService.InvokeAsync<int>("addDraggableMarker", MapId, point, title,
        popupDescription, BuildIconUrl(iconUrl));
    }

    string BuildIconUrl(string iconUrl) =>
       iconUrl == null ? iconUrl :
       iconUrl.Contains('.') ? iconUrl :
       $"{ContentHelper.ContentPath}/css/images/{iconUrl}.png";

    async ValueTask SetDotNetObjectReference()
    {
        if (MarkerHelper == null)
        {
            MarkerHelper = DotNetObjectReference.Create(this); //hay que pasar la instancia donde esta el metodo de .NET
            //que va a invocar el codigo javascript
            await LeafletService.InvokeVoidAsync("setMarkerHelper", MapId,
                MarkerHelper, nameof(DragendHandler));
        }
    }


    public async ValueTask RemoveMarkersAsync() =>
       await LeafletService.InvokeVoidAsync("removeMarkers", MapId);


    public async Task SetViewMapAsync(LeafletLatLong point) =>
      await LeafletService.InvokeVoidAsync("setView", MapId, point);

    public async ValueTask DrawCircleAsync(LeafletLatLong center, string lineColor, string fillColor, double fillOpacity, double radius) =>
      await LeafletService.InvokeVoidAsync("drawCircle", MapId, center, lineColor, fillColor, fillOpacity, radius);


    public async ValueTask MoveMarkerAsync(int markerId, LeafletLatLong newPosition)
    {
        await LeafletService.InvokeVoidAsync("moveMarker", MapId, markerId, newPosition);
    }

    //video 14 1:40
    public async ValueTask SetPopupMarkerContentAsync(int markerId, string content) =>
      await LeafletService.InvokeVoidAsync("setPopupMarkerContent",
          MapId, markerId, content);

    #endregion

    #region JavaScript Events
    //video 13 2:40    , video 14 0:11
    [JSInvokable]
    //este  metodo se va a ejecutar cuando se suelte la marca,  va a recibir algo de javascript
    public async Task DragendHandler(DragendMarkerEventArgs e)
    {
        //Console.WriteLine(
        //    $"DragedHandler: markerid:{e.MarkerId}: {e.Position.Latitude}, {e.Position.Longitude}");
        await OnMarkerDragendAsync.InvokeAsync(e);
    }

    #endregion

    #region IAsyncDisposable  
    //elimina el control map de Javascript cuando se cierra la aplicacion o deja de utilizarse
    public async ValueTask DisposeAsync()
    {
        await LeafletService.InvokeVoidAsync("deleteMap", MapId);
        MarkerHelper?.Dispose();
    }
    #endregion
}
