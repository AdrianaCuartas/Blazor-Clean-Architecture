namespace BlazingPizza.Shared.BusinessObjects.ValueObjects;
public record LatLong
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }

    public LatLong()
    {

    }
    public LatLong(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }


}
