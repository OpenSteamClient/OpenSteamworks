#!/bin/sh
set -e

cd OpenSteamworks.Data
BuiltVersion_OSWData="$(dotnet msbuild -getproperty:Version)"
dotnet pack -c Release
cd ..

cd artifacts/package
mkdir -p pkgsrc
nuget add ./release/OpenSteamworks.Data.$BuiltVersion_OSWData.nupkg -Source ./pkgsrc/
cd ../..

cd OpenSteamworks
BuiltVersion_OSW="$(dotnet msbuild -getproperty:Version)"
./package.sh
cd ..

cd artifacts/package
mkdir -p pkgsrc
nuget add ./release/OpenSteamworks.$BuiltVersion_OSW.nupkg -Source ./pkgsrc/
cd ../..

cd OpenSteamworks.Messaging
dotnet pack -c Release