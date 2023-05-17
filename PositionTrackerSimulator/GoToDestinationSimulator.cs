namespace PositionTrackerSimulator;
public class GoToDestinationSimulator : IDisposable
{
    readonly Dictionary<int, TrackedRoute> TrackedRoutes = new();
    //cada que se envie una orden se guarda los origenes calculados
    readonly Dictionary<int, RouteCached> RoutesCache = new();

    public Task<PositionTrackerLatLong> SubscribeAsync(RouteInfo routeInfo)
    {
        TrackedRoute TrackedRoute = GetTrackedRouteData(routeInfo);
        TrackedRoutes.TryAdd(routeInfo.RouteId, TrackedRoute);

        NotifyPosition(routeInfo.RouteId);

        return Task.FromResult(TrackedRoute.Origin);
    }

    public void UnSubscribe(int routeId)
    {
        if (TrackedRoutes.TryGetValue(routeId, out TrackedRoute route))
        {
            route.Timer.Dispose();
            TrackedRoutes.Remove(routeId);
        }
    }

    private TrackedRoute GetTrackedRouteData(RouteInfo routeInfo)
    {
        RouteCached Route;
        if (!RoutesCache.TryGetValue(routeInfo.RouteId, out Route))
        {
            Route = new();
            Route.Degree = new Random().Next(0, 360);
            double DistanceInMeters = routeInfo.RouteDistanceKm * 1000.0;
            Route.Origin = routeInfo.Destination.AddMeters(
                Route.Degree, -DistanceInMeters);
            RoutesCache.Add(routeInfo.RouteId, Route);
        }

        var Timer = new System.Timers.Timer(
            routeInfo.NotificationIntervalInSeconds * 1000);
        Timer.Elapsed += (sender, e) => NotifyPosition(routeInfo.RouteId);
        Timer.Start();

        return new TrackedRoute(Route.Origin, routeInfo.Destination, Route.Degree,
            routeInfo.RouteDistanceKm, routeInfo.SpeedKmXHr,
            routeInfo.TravelStartTime, routeInfo.Callback, Timer);
    }

    private void NotifyPosition(int routeId)
    {
        var TrackedRoute = TrackedRoutes[routeId];
        PositionNotification Notification = GetPositionNotification(routeId);
        TrackedRoute.Callback(Notification);
        if (Notification.Finished)
        {
            UnSubscribe(routeId);
        }
    }

    private PositionNotification GetPositionNotification(int routeId)
    {
        var TrackedRoute = TrackedRoutes[routeId];
        PositionNotification Notification;

        var HoursInRoute = (DateTime.Now - TrackedRoute.TravelStartTime).TotalHours;
        if (HoursInRoute >= 0)
        {
            double CurrentDistanceInKm = TrackedRoute.SpeedKmXHr * HoursInRoute;
            if (CurrentDistanceInKm >= TrackedRoute.TotalDistanceKm)
            {
                CurrentDistanceInKm = TrackedRoute.TotalDistanceKm;
            }
            var CurrentPosition = TrackedRoute.Origin.AddMeters(
                TrackedRoute.Degree, CurrentDistanceInKm * 1000.0);
            Notification = new PositionNotification(routeId, CurrentPosition,
                CurrentDistanceInKm * 1000.0,
                CurrentDistanceInKm == TrackedRoute.TotalDistanceKm);
        }
        else
        {
            Notification = new PositionNotification(routeId,
                TrackedRoute.Origin, 0, false);
        }
        return Notification;
    }

    public void Dispose()
    {
        foreach (var Route in TrackedRoutes)
        {
            Route.Value.Timer.Dispose();
        }
        TrackedRoutes.Clear();
    }
}
