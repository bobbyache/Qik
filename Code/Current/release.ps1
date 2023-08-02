dotnet publish -c release
Remove-Item -Recurse -Force "C:\Program Files\Qik\*"
Copy-Item -Recurse -Force "QikConsole\bin\Release\net7.0\publish\*" "C:\Program Files\Qik\"
