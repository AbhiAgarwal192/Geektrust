dotnet restore -s https://api.nuget.org/v3/index.json
dotnet build -o geektrust
dotnet test "./Traffic.UnitTests/Traffic.UnitTests.csproj"
dotnet geektrust/geektrust.dll "./Input.txt"