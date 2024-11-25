using System;
using System.Threading;

namespace OpenSteamworks.Utils;

internal sealed class UsingSemaphore : IDisposable
{
    private bool isReleased = false;
    private readonly SemaphoreSlim semaphore;

    public UsingSemaphore(SemaphoreSlim semaphore)
    {
        this.semaphore = semaphore;
        semaphore.Wait();
    }
    
    public void Dispose()
    {
        ObjectDisposedException.ThrowIf(isReleased, this);
        isReleased = true;
        
        semaphore.Release();
    }
}