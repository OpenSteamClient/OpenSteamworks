#!/bin/sh
set -e

mkdir -p artifacts/package/pkgsrc
PKGSRC_DIRECTORY="$(realpath artifacts/package/pkgsrc)"

if ! [ -x "$(command -v nuget)" ]; then
  echo "No nuget! Downloading..."
  sudo curl -o /tmp/nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
  alias nuget="mono /tmp/nuget.exe"
else
  alias nuget="nuget"
fi
  
nuget_add ()
{
  nuget add "$1" -Source "$PKGSRC_DIRECTORY"
}

OSWVersion="$(dotnet msbuild -getproperty:CommonVersion Directory.Build.props)"

# Ugh, have to build this explicitly.
cd SourceGeneratorsKit
dotnet build
dotnet build -c Release
cd ..

cd OpenSteamworks.Protobuf
dotnet pack -c Release /p:IsPacking=true
cd ..

cd OpenSteamworks.Data
dotnet pack -c Release /p:IsPacking=true
cd ..

cd artifacts/package/release
nuget_add ./OpenSteamworks.Data."$OSWVersion".nupkg
nuget_add ./OpenSteamworks.Protobuf."$OSWVersion".nupkg
cd ../../..

cd OpenSteamworks
./package.sh
cd ..

cd artifacts/package/release
nuget_add ./OpenSteamworks."$OSWVersion".nupkg
cd ../../..

cd OpenSteamworks.Messaging
dotnet pack -c Release /p:IsPacking=true
cd ..

cd artifacts/package/release
nuget_add ./OpenSteamworks.Messaging."$OSWVersion".nupkg
cd ../../..

cd OpenSteamworks.Messaging.SharedConnection
dotnet pack -c Release /p:IsPacking=true
cd ..