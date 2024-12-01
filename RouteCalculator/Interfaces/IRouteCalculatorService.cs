public interface IRouteCalculatorService
{
    List<Trip> GetRoutes(string startingPoint, string endPoint);
    int GetDistanceByRoute(string route);
    bool IsRouteExist(string route);
}