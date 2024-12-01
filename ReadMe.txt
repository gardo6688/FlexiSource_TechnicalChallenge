FlexiSouce Technical Challenge

Requirements: 
Develop a .Net console application that finds train routes between towns given an input file. In the
input file, every line represents a direct link from one town to another and its length (distance).
The format of lines in the file is <From Town A>,<To Town B>,<distance between Town A and Town
B>
Input file Input.txt is attached
The application has to successfully run the following tests
• Test #1: The distance of the route A=>B=>C is 9
• Test #2: The distance of the route A=>D is 5
• Test #3: The distance of the route A=>D=>C is 13
• Test #4: The distance of the route A=>E=>B=>C=>D is 22
• Test #5: Route A=>E=>D doesn't exist
• Test #6: Number of trips from C to C with maximum 3 stops is 2 ( C=>D=>C, C=>E=>B=>C )
• Test #7: Number of trips from A to C with exactly 4 stops is 3 ( A=>B=>C=>D=>C,
A=>D=>C=>D=>C, A=>D=>E=>B=>C )
• Test #8: The length of the shortest route from A to C is 9 ( A=>B=>C )
• Test #9: The length of the shortest route from B to B is 9 ( B=>C=>E=>B )
• Test #10: The number of trips from C to C with distance less than 30 is 7 ( C=>D=>C,
C=>D=>C=>E=>B=>C, C=>D=>E=>B=>C, C=>E=>B=>C, C=>E=>B=>C=>D=>C,
C=>E=>B=>C=>E=>B=>C, C=>E=>B=>C=>E=>B=>C=>E=>B=>C )

The solution has to include unit tests and a ReadMe file that explains design decisions.
The submission will be evaluated based not only on the accuracy of calculations in the tests, but also
on the effective application of software design patterns.


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