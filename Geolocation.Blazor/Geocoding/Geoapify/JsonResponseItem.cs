namespace Geolocation.Blazor.Geocoding.Geoapify;

internal class JsonResponseItem
{
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string Formatted { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string Address_Line1 { get; set; }
    public string Address_Line2 { get; set; }
}
