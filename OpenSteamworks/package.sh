#!/bin/bash

. ../nuget.sh

dotnet publish -c Release --runtime win-x64
dotnet publish -c Release --runtime linux-x64

export OSW_VERSION="$(dotnet msbuild -getproperty:Version)"
cat OpenSteamworks.nuspec.in | envsubst > OpenSteamworks.nuspec
$NUGET_CMD pack OpenSteamworks.nuspec -OutputDirectory ../artifacts/package/release/
