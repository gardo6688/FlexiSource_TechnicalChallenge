using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using RouteCalculator;

namespace RouteCalculator.Test
{
    public class UnitTests : IDisposable
    {
        private IServiceProvider _serviceProvider;
        private IRouteCalculatorService _routeCalcService;

        [SetUp]
        public void Setup()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IRouteRepository, RouteRepository>();
            serviceCollection.AddTransient<IRouteCalculatorService, RouteCalculatorService>();
            _serviceProvider = serviceCollection.BuildServiceProvider();
            _routeCalcService = _serviceProvider.GetRequiredService<IRouteCalculatorService>();
        }

        [Test]
        public void Test1_Distance_Of_The_Route_ABC()
        {
            var result = _routeCalcService.GetDistanceByRoute("A=>B=>C");
            Assert.AreEqual(9, result);
        }

        [Test]
        public void Test2_Distance_Of_The_Route_AD()
        {
            var result = _routeCalcService.GetDistanceByRoute("A=>D");
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Test3_Distance_Of_The_Route_ADC()
        {
            var result = _routeCalcService.GetDistanceByRoute("A=>D=>C");
            Assert.AreEqual(13, result);
        }

        [Test]
        public void Test4_Distance_Of_The_Route_AEBCD()
        {
            var result = _routeCalcService.GetDistanceByRoute("A=>E=>B=>C=>D");
            Assert.AreEqual(22, result);
        }

        [Test]
        public void Test5_Existence_Of_The_Route_AED()
        {
            var result = _routeCalcService.IsRouteExist("A=>E=>D");
            Assert.AreEqual(false, result);

        }

        [Test]
        public void Test6_Number_Of_Trips_C_to_C_Max_3_Stops()
        {
            var result = _routeCalcService.GetRoutes("C","C").Count(r => r.TotalStops <= 3);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Test7_Number_Of_Trips_C_to_C_Max_3_Stops()
        {
            var result = _routeCalcService.GetRoutes("A","C").Count(r => r.TotalStops == 4);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Test8_Len_Of_Shortest_Route_A_To_C()
        {
            var result = _routeCalcService.GetRoutes("A","C").OrderBy(p => p.Paths.Length).FirstOrDefault();
            Assert.AreEqual(9, result.TotalDistance);
        }

        [Test]
        public void Test9_Len_Of_Shortest_Route_B_To_B()
        {
            var result = _routeCalcService.GetRoutes("B","B").OrderBy(p => p.Paths.Length).FirstOrDefault();
            Assert.AreEqual(9, result.TotalDistance);
        }

        [Test]
        public void Test10_Number_Of_Trips_C_to_C_Distance_LessThan_30()
        {
            var result = _routeCalcService.GetRoutes("C","C").Count(r => r.TotalDistance < 30);
            Assert.AreEqual(7, result);
        }


        [TearDown]
        public void TearDown()
        {
            if (_serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
        public void Dispose()
        {
            TearDown();
        }
    }
}
