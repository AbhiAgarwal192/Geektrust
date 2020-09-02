dotnet restore -s https://api.nuget.org/v3/index.json
dotnet build -o geektrust
dotnet test "./FamilyTree.UnitTests/FamilyTree.UnitTests.csproj"
dotnet geektrust/geektrust.dll "./Input.txt"