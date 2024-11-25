# OpenSteamworks
Use Steam's internal ClientAPI. With this you can build custom tools to interact with the local Steam Client to provide functionality not available through the official Steamworks API.

## Features
- Raw access to underlying ClientAPI interfaces
- Managed helpers to make using ClientAPI easier

## Requirements
You'll need to provide your own binaries, versioned exactly the same as `Manifests/<platform manifest>`, regardless of connection mode choice. 

> [!CAUTION]
> This library does not check the version, instead various issues will manifest at runtime like segfaults, wrong functions being called, issues connecting to existing clients, etc.

## Connection modes
### Locally running Steam Client
This library can connect to a locally running Steam Client (referred to as ExistingClient).
This connection mode requires that the version of this library matches the locally installed Steam Client version, if the versions don't match, you cannot connect to the local client.
This is the mode you should use when building small apps like compat tool or library managers that enhance ValveSteam. 

> [!TIP]
> When developing OpenSteamworks, you may [pin your local Steam Client's version](https://github.com/OpenSteamClient/archived_packages) for ease of development.
> This is not recommended for long-time use though, as running an outdated Steam Client may lead to security issues or nonfunctionality.
> Also, you won't get cool new Steam features.

#### Environment
No special environment is expected, as this is the mode apps use to connect.

#### Limitations
- No access to some APIs, such as IClientVR
- Limited access to some APIs, such as IClientCompat, IClientApps
- Exact version match is required.

#### Features
- Poking and prodding around the locally running client.

### Global instance
This is the preferred way of using this library, as it minimizes the chance of version incompatibility.
- You will act as the locally running Steam Client, and apps will connect to your process.
- This is the preferred mode when making a custom frontend for Steam.
- You should mark your process with `SteamPIDFile` so that apps can detect Steam is running.

#### Environment
Running as the global instance requires a very specific environment.
On Windows:
- A registry key (`HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam\SteamPID`) needs to be world-writable.
- The Steam Client Service (or an alternative) should be installed.

On Linux:
- You are expected to run inside the Steam Runtime, and pin required libraries.
- `steamservice.so` is required to be running for Proton to work correctly, see [serviced](OpenSteamworks.Native/serviced/main.cpp) for details. 

On any platform:
- Driver query EXEs, 32-bit support libraries, environment variables and more ancillary files may be expected.

#### Limitations
- The environment is quite tricky.
- Has a risk of corruption if two clients are running at the same time.
- Cannot interface with the currently running client.

#### Features
- Access to ConCommands and ConVars to tweak client functionality
- Full access to every API
- Hooking functions is supported
