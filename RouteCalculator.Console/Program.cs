using System;
using System.IO;
using RouteCalculator;
using Microsoft.Extensions.DependencyInjection;

namespace RouteCalculator.Console;

class Program
{
    static void Main(string[] args)
    {
        // Configure DI
        var serviceCollection = new ServiceCollection();

        ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Resolve the service and run it
        var _service = serviceProvider.GetRequiredService<IRouteCalculatorService>();

        System.Console.WriteLine("Please Input Starting Point: ");
        var startPoint = System.Console.ReadLine();
        System.Console.WriteLine("Please Input Ending Point: ");
        var endPoint = System.Console.ReadLine();

        var possibleRoutes = _service.GetRoutes(startPoint, endPoint);

        System.Console.WriteLine("Possible routes are:");

        possibleRoutes.ToList().ForEach(r =>
        {
            System.Console.WriteLine($"{r.Paths},{r.TotalDistance}");
        });


    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IRouteRepository, RouteRepository>();

        services.AddTransient<IRouteCalculatorService, RouteCalculatorService>();
    }
}




