This solution is built on .net core 3.1.
To build the solution, run the below command:
dotnet build -o geektrust.

To run the solution run the following command:
dotnet geektrust/geektrust.dll <Absolute path of test file>

There are no third party libraries being used other than standard dotnet core framework libraries.

Input Format:
WEATHER ORBIT_1_TRAFFIC_SPEED ORBIT_2_TRAFFIC_SPEED

Output Format:
VEHICLE_NAME ORBIT_NO

To run the unit tests, you can execute the below command:
dotnet test "./Traffic.UnitTests/Traffic.UnitTests.csproj"

Assumptions:
1) Vehicle, Weather and Orbit data will not change.
2) Integer values are assumed for the orbit length and traffic speeds.
