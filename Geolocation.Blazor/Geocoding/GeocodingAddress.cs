namespace Geolocation.Blazor.Geocoding;

public class GeocodingAddress
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public string DisplayAddress { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }

    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string HouseNumber { get; set; }

    public string Street { get; set; }
}
