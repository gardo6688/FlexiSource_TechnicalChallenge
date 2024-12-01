FlexiSouce Technical Challenge
Solution:

This solution is subjective based on what I understand on the requirements provided. Solution could be different from the expected or there are any efficient design than this, but this is the representation of my coding disipline and style.

Created 3 projects:

1. RouteCalculator Project: Dynamic library project that contains the capturing of data and base logic / computation for inquiring details about the routes.
    ->Implemented 2 Services
        -> RouteCalculatorService: (Core)
            ->GetRoutes: Get all the possible routes based on the starting and ending point input.
                -> This use recursion technique for finding routes in depth. There is a limit of atleast 10 steps to avoid infinite looping process.
            ->GetDistanceByRoute: Get the total distance based on the route input.
            ->IsRouteExist: Checking of route existence based on the input
        -> RouteRepository:
            ->GetRouteData: Capture data from the input file.
    ->Implemented 2 models:
        ->Trip: Computed routes, Total Distance, Total Stops.
        ->Route: Class representation on based on the input.txt

2. RouteCalculator.Console Project: Built as Console App. Serve as user interface. Injects the 2 services from RouteCalculator project.
    -> User interaction would be allowing to input the starting point to endpoint.
    -> Application will display all the possible routes plus the total distance.

3. RouteCalculator.Test Project: Built with NUnit. Injects 2 services from RouteCalculator project.
    -> 10 test scenarios based on the requirement. 


Dependencies: NUnit.Framework, Microsoft.Extensions.DependencyInjection
Built using .Net Core 8
