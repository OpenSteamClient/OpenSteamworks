#!/bin/sh
set -e

cd OpenSteamworks.Data
dotnet pack -c Release
cd ..

cd artifacts/package
mkdir pkgsrc
nuget add ./release/OpenSteamworks.Data.1.0.0.nupkg -Source ./pkgsrc/

cd ../..
cd OpenSteamworks
./package.sh
