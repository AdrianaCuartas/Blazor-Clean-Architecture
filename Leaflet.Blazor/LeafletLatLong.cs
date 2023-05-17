namespace Leaflet.Blazor;
public record struct LeafletLatLong
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public LeafletLatLong(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    //public LeafletLatLong AddMetters(double theta, double distance)
    //{
    //    var X = Math.Cos(theta) * distance;
    //    var Y = Math.Sin(theta) * distance; //Y en metros

    //    //Del centro de la tierra hacia un punto de  latitud hay ciertos grados

    //    //el radio de la tierra: en metros:
    //    double EarthEquatorialRadiusInMeters = 6378137;
    //    //los grados por metro de latitud:
    //    var DegreesPerMeterOfLatitude =
    //        360 / (2 * Math.PI * EarthEquatorialRadiusInMeters); //1 metro en grados

    //    // Y * DegreesPerMeterOfLatitude es para llevar metros a grados:
    //    var NewLatitude = Latitude + (Y * DegreesPerMeterOfLatitude);

    //    //longitud en grados:
    //    var LongitudeGradesToAdd = X * DegreesPerMeterOfLatitude;

    //    LongitudeGradesToAdd /= Math.Cos(Latitude * (Math.PI / 180));

    //    var NewLongitude = Longitude + LongitudeGradesToAdd;

    //    return new LeafletLatLong(NewLatitude, NewLongitude);
    //}


}