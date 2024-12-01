namespace RouteCalculator;

public class RouteRepository : IRouteRepository
{
    public List<Route> GetRouteData()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "input.txt");

        List<Route> routes = new List<Route>();
        foreach (string line in File.ReadLines(filePath))
        {
            var record = line.Split(',');
            routes.Add(new Route()
            {
                StartPoint = record[0].ToString(),
                EndPoint = record[1].ToString(),
                Distance = int.Parse(record[2].ToString())
            });
        }
        return routes;
    }
}