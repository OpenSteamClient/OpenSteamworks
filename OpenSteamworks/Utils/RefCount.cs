using System;
using System.Threading;

namespace OpenSteamworks.Utils;

/// <summary>
/// A reference count helper.
/// Prevents the Count from going under 0, and allows you to perform deconstruction and construction safely under a lock.
/// </summary>
public sealed class RefCount
{
    private sealed class LockDisposable(object? lockObj, bool lockTaken) : IDisposable
    {
        public static LockDisposable NoOp = new(null, false);
        
        public void Dispose()
        {
            if (!lockTaken)
                return;

            if (lockObj == null)
                return;
            
            Monitor.Exit(lockObj);
        }
    }
    
    public RefCount() { }
    
    private readonly object lockObj = new();
    private int count = 0;
    
    /// <summary>
    /// Call this function when the reference count should increase.
    /// </summary>
    /// <param name="shouldConstruct">True if initialisation should be done</param>
    /// <returns>A disposable which you should dispose when you're done running construction logic. You should always dispose this as soon as possible.</returns>
    public IDisposable Increment(out bool shouldConstruct) {
        bool lockTaken = false;
        Monitor.Enter(lockObj, ref lockTaken);
        
        shouldConstruct = count == 0;
        count++;
        
        return new LockDisposable(lockObj, lockTaken);
    }

    /// <summary>
    /// Call this function when the reference count should decrease.
    /// </summary>
    /// <param name="shouldDeconstruct">True if deconstruction should be done</param>
    /// <returns>A disposable which you should dispose when you're done running deconstruction logic. You should always dispose this as soon as possible.</returns>
    public IDisposable Decrement(out bool shouldDeconstruct)
    {
        bool lockTaken = false;
        Monitor.Enter(lockObj, ref lockTaken);
        
        if (count-- < 0)
            count = 0;
        
        shouldDeconstruct = count == 0;
        return new LockDisposable(lockObj, lockTaken);
    }
}