#!/bin/sh
set -e

mkdir -p artifacts/package/pkgsrc

cd OpenSteamworks.Protobuf
BuiltVersion_OSWProtobuf="$(dotnet msbuild -getproperty:Version)"
dotnet pack -c Release
cd ..

cd OpenSteamworks.Data
BuiltVersion_OSWData="$(dotnet msbuild -getproperty:Version)"
dotnet pack -c Release
cd ..

cd artifacts/package
nuget add ./release/OpenSteamworks.Data.$BuiltVersion_OSWData.nupkg -Source ./pkgsrc/
nuget add ./release/OpenSteamworks.Protobuf.$BuiltVersion_OSWProtobuf.nupkg -Source ./pkgsrc/
cd ../..

cd OpenSteamworks
BuiltVersion_OSW="$(dotnet msbuild -getproperty:Version)"
./package.sh
cd ..

cd artifacts/package
nuget add ./release/OpenSteamworks.$BuiltVersion_OSW.nupkg -Source ./pkgsrc/
cd ../..

cd OpenSteamworks.Messaging
dotnet pack -c Release
cd ..