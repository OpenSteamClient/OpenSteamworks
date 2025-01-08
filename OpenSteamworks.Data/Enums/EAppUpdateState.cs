using System;
using System.Runtime.InteropServices;

namespace OpenSteamworks.Data.Enums;

[Flags]
public enum EAppUpdateState : UInt32
{
    /// <summary>
    /// Not updating.
    /// </summary>
    None = 0,
    
    /// <summary>
    /// Running an update.
    /// </summary>
    RunningUpdate = 1 << 0,
    Reconfiguring = 1 << 1,
    
    /// <summary>
    /// Validating is the process where existing, committed (installed) game files are checked to see if a patch can be applied.
    /// </summary>
    Validating = 1 << 2,
    // Removed/unused slot.
    
    /// <summary>
    /// Preallocating is the process where the file's folder and file structure are created, including reserving space for the files.
    /// This happens into the staging ("downloading") directory
    /// </summary>
    Preallocating = 1 << 4,
    
    /// <summary>
    /// Downloading chunks, combining them and unpacking the result.
    /// </summary>
    Downloading = 1 << 5,
    
    /// <summary>
    /// Files are being downloaded to a staging directory ("downloading")
    /// </summary>
    Staging = 1 << 6,
    
    /// <summary>
    /// Verifying is the part of the download where installed files get verified and checked for corruption.
    /// </summary>
    Verifying = 1 << 7,
    
    /// <summary>
    /// Committing is the process where staged files are copied to the app's install directory.
    /// </summary>
    Committing = 1 << 8,
    RunningScript = 1 << 9,
    Stopping = 1 << 10,
};