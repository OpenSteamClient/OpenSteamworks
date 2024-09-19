#!/bin/sh

dotnet publish -c Release --runtime win-x64
dotnet publish -c Release --runtime linux-x64
nuget pack OpenSteamworks.nuspec -OutputDirectory ../artifacts/package/release/