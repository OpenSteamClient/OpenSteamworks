#!/bin/bash
# Helper script to use nuget CLI on systems without nuget (Github actions)

export NUGET_CMD="nuget"

if ! [ -x "$(command -v nuget)" ]; then
  echo "No nuget! Setting up locally."

  if [ ! -f /tmp/nuget.exe ]; then
    curl -o /tmp/nuget.exe https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
  fi

  export NUGET_CMD="mono /tmp/nuget.exe"
fi

mkdir -p artifacts/package/pkgsrc
PKGSRC_DIRECTORY="$(realpath artifacts/package/pkgsrc)"
nuget_add ()
{
  $NUGET_CMD add "$1" -Source "$PKGSRC_DIRECTORY"
}

export -f nuget_add
