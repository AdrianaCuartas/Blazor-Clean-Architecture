namespace Geolocation.Blazor.Geocoding;

public interface IGeocoder
{
    Task<GeocodingAddress> GetGeocodingAddressAsync(
        double latitude, double longitude);
}