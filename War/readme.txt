This solution is built on .net core 3.1.
To build the solution, run the below command:
dotnet build -o geektrust.

To run the solution run the following command:
dotnet geektrust/geektrust.dll <Absolute path of test file>

There are no third party libraries being used other than standard dotnet core framework libraries.

Input Format:
FALICORNIA_ATTACK 100H 101E 20AT 5SG

Output Format:
WINS 52H 50E 10AT 3SG

WINS or LOSES indicate whether Lengaburu Army won the battle or not 
against Falicornia.

H indicates the Horse battalion units, 
E indicates the Elephant battalion units, 
AT indicates the Armoured Tank units, 
SG indicates the Sling Gun units

To run the unit tests, you can execute the below command:
dotnet test "./War.UnitTests/War.UnitTests.csproj"

Assumptions:
1) No other input other than the given input in given format.
2) King Shan either wins or loses. There is no middle ground.
3) King Shan himself decides which battalion to send for attack using the rules of war.
4) King Shan is at peace with neighbouring kingdoms and neighbouring evil kingdoms might attack. 