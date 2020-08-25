This solution is built on .net core 3.1.
To build the solution, run the below command:
dotnet build -o geektrust.

To run the solution run the following command:
dotnet geektrust/geektrust.dll <Absolute path of test file>

There are no third party libraries being used other than standard dotnet core framework libraries.

Input Format:
KINGDOM_1  SECRET_MSG_TO_KINGDOM_1 
KINGDOM_2  SECRET_MSG_TO_KINGDOM_2
… 
KINGDOM_N  SECRET_MSG_TO_KINGDOM_N

Output Format:
RULER  ALLY_KINGDOM_1, ALLY_KINGDOM_N

Assumptions:
1) Only Gorilla King sends the message and wants to rule Southeros.