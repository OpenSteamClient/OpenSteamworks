using System;
using System.Threading;

namespace OpenSteamworks.Utils;

/// <summary>
/// A reference count helper.
/// Prevents the Count from going under 0, and allows you to perform deconstruction and construction safely under a lock.
/// </summary>
public sealed class RefCount
{
    private sealed class LockDisposable(SemaphoreSlim lockObj) : IDisposable
    {
        public void Dispose()
        {
            lockObj.Release();
        }
    }

    private readonly SemaphoreSlim lockObj = new(1, 1);
    private int count;
    
    /// <summary>
    /// Call this function when the reference count should increase.
    /// </summary>
    /// <param name="shouldConstruct">True if initialisation should be done</param>
    /// <returns>A disposable which you should dispose when you're done running construction logic. You should always dispose this as soon as possible.</returns>
    public IDisposable Increment(out bool shouldConstruct) {
        lockObj.Wait();
        
        shouldConstruct = count == 0;
        count++;
        
        return new LockDisposable(lockObj);
    }

    /// <summary>
    /// Call this function when the reference count should decrease.
    /// </summary>
    /// <param name="shouldDeconstruct">True if deconstruction should be done</param>
    /// <returns>A disposable which you should dispose when you're done running deconstruction logic. You should always dispose this as soon as possible.</returns>
    public IDisposable Decrement(out bool shouldDeconstruct)
    {
        lockObj.Wait();
        
        if (count-- < 0)
            count = 0;
        
        shouldDeconstruct = count == 0;
        return new LockDisposable(lockObj);
    }
}