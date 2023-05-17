using Microsoft.JSInterop;

namespace Geolocation.Blazor;

public class GeolocationService : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> ModuleTask;

    public GeolocationService(IJSRuntime jsRuntime)
    {
        ModuleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Geolocation.Blazor/geolocation.js").AsTask());
    }

    //nota las tuplas no pueden se serializadas 2:20
    public async ValueTask<GeoLocationLatLong> GetPositionAsync()
    {
        var Module = await ModuleTask.Value;
        GeoLocationLatLong Position = default;
        try
        {
            Position = await Module.InvokeAsync<GeoLocationLatLong>("getPositionAsync");
        }
        catch (Exception ex)
        {

            Console.WriteLine($"GetPosition:{ex.Message}");
        }
        return Position;
    }

    public async ValueTask DisposeAsync()
    {
        if (ModuleTask.IsValueCreated)
        {
            var module = await ModuleTask.Value;
            await module.DisposeAsync();
        }
    }
}