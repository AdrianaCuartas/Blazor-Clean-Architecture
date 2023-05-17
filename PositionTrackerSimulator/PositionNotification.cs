namespace PositionTrackerSimulator;

public class PositionNotification
{
    public int RouteId { get; }

    public PositionTrackerLatLong CurrentPosition { get; }

    public double CurrentDistanceInMeters { get; }
    public bool Finished { get; }

    public PositionNotification(int routeId,
        PositionTrackerLatLong currentPosition,
        double currentDistanceInMeters, bool finished)
    {
        RouteId = routeId;
        CurrentPosition = currentPosition;
        CurrentDistanceInMeters = currentDistanceInMeters;
        Finished = finished;
    }
}
