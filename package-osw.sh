#!/bin/sh
set -e

mkdir -p artifacts/package/pkgsrc

OSWVersion="$(dotnet msbuild -getproperty:CommonVersion Directory.Build.props)"

cd OpenSteamworks.Protobuf
dotnet pack -c Release /p:IsPacking=true
cd ..

cd OpenSteamworks.Data
dotnet pack -c Release /p:IsPacking=true
cd ..

cd artifacts/package
nuget add ./release/OpenSteamworks.Data."$OSWVersion".nupkg -Source ./pkgsrc/
nuget add ./release/OpenSteamworks.Protobuf."$OSWVersion".nupkg -Source ./pkgsrc/
cd ../..

cd OpenSteamworks
./package.sh
cd ..

cd artifacts/package
nuget add ./release/OpenSteamworks."$OSWVersion".nupkg -Source ./pkgsrc/
cd ../..

cd OpenSteamworks.Messaging
dotnet pack -c Release /p:IsPacking=true
cd ..

cd artifacts/package
nuget add ./release/OpenSteamworks.Messaging."$OSWVersion".nupkg -Source ./pkgsrc/
cd ../..

cd OpenSteamworks.Messaging.SharedConnection
dotnet pack -c Release /p:IsPacking=true
cd ..