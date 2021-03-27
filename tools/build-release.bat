@echo off

dotnet publish ..\src\SpARe.csproj -r:win-x64 -c:Release-SelfContained
dotnet publish ..\src\SpARe.csproj -r:win-x86 -c:Release-SelfContained

dotnet publish ..\src\SpARe.csproj -r:win-x64 -c:Release-FrameworkDependent
dotnet publish ..\src\SpARe.csproj -r:win-x86 -c:Release-FrameworkDependent
