using System;
using System.Collections.Generic;
using System.Linq;

namespace RouteCalculator;

public class RouteCalculatorService : IRouteCalculatorService
{
    private readonly List<Route> _routes;
    private const int MaxDepth = 10; // Limiter to prevent infitnite loops due to cyclic paths.

    public RouteCalculatorService(IRouteRepository routeRepository)
    {
        _routes = routeRepository.GetRouteData();
    }

    private List<List<Route>> ExtractRoutes(string startPoint, string endPoint)
    {
        var result = new List<List<Route>>();
        FindRoutes(startPoint, endPoint, new List<Route>(), result, 0);
        return result;
    }

    private void FindRoutes(string currentPoint, string destination, List<Route> currentPath, List<List<Route>> result, int depth)
    {
        if (depth > MaxDepth) return;

        // Add to path if destination has reached.
        if (currentPoint == destination && currentPath.Count > 0)
        {
            result.Add(new List<Route>(currentPath));
        }

        // Check for possible routes
        foreach (var route in _routes.Where(r => r.StartPoint == currentPoint))
        {
            currentPath.Add(route);

            // Recursively checking of path. Increment the depth for limiting purposes.
            FindRoutes(route.EndPoint, destination, currentPath, result, depth + 1);

            // Remove the current path to refresh.
            currentPath.RemoveAt(currentPath.Count - 1);
        }
    }

    private string getFirstRoute(string input)
    {
        return input[0].ToString();
    }

    private string getLastRoute(string input)
    {
        return input[input.Length - 1].ToString();
    }

    public List<Trip> GetRoutes(string startingPoint, string endPoint)
    {
        var result = new List<Trip>();
        var allRoutes = ExtractRoutes(startingPoint, endPoint);
        //Create instance of trips based on the finds.
        foreach (var path in allRoutes)
        {
            var trip = new Trip()
            {
                Paths = string.Join("=>", path.Select(r => r.StartPoint)) + "=>" + endPoint,
                TotalDistance = path.Sum(r => r.Distance),
                TotalStops = path.Count()
            };
            result.Add(trip);
        }

        return result;
    }

    public int GetDistanceByRoute(string route)
    {
        var start = getFirstRoute(route);
        var end = getLastRoute(route);
        var selected = GetRoutes(start, end).FirstOrDefault(r => r.Paths == route);
        if (selected != null)
            return selected.TotalDistance;
        else
            return 0;
    }

    public bool IsRouteExist(string route)
    {
        var start = getFirstRoute(route);
        var end = getLastRoute(route);
        var selected = GetRoutes(start, end).FirstOrDefault(r => r.Paths == route);
        return selected != null;
    }
}

