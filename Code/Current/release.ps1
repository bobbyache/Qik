dotnet clean
dotnet restore --no-cache
dotnet publish -c release
Remove-Item -Recurse -Force "C:\Programs\QikConsole\*"
Copy-Item -Recurse -Force ".\QikConsole\bin\Release\net7.0\publish\*" "C:\Programs\QikConsole\"
