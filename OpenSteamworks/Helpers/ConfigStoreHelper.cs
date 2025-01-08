using System;
using System.ComponentModel;
using OpenSteamClient.Logging;
using OpenSteamworks.Callbacks;
using OpenSteamworks.Callbacks.Structs;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Generated;

namespace OpenSteamworks.Helpers;

public sealed class ConfigStoreHelper : IDisposable
{
    public abstract class ConfigKeyBase<T> : INotifyPropertyChanged
    {
        protected ConfigStoreHelper Helper { get; }
        public EConfigStore Store { get; init; }
        public string Key { get; init; }

        protected abstract void SetValue(T val);
        protected abstract T GetValue();

        public T Value
        {
            get => GetValue();
            set => SetValue(value);
        }

        public bool Remove()
            => Helper.Remove(Store, Key);

        public bool IsSet
            => Helper.IsSet(Store, Key);
        
        public event PropertyChangedEventHandler? PropertyChanged;
        protected ConfigKeyBase(ConfigStoreHelper helper, EConfigStore store, string key)
        {
            this.Helper = helper;
            this.Store = store;
            this.Key = key;

            Helper.ConfigStoreChanged += OnConfigStoreChanged;
        }

        private void OnConfigStoreChanged(object? sender, ConfigStoreChangedEventArgs e)
        {
            if (e.Key != Key)
                return;
            
            PropertyChanged?.Invoke(this, new(nameof(Value)));
        }

        ~ConfigKeyBase()
        {
            Helper.ConfigStoreChanged -= OnConfigStoreChanged;
        }
    }

    private sealed class ConfigKeyInt : ConfigKeyBase<int>
    {
        public ConfigKeyInt(ConfigStoreHelper helper, EConfigStore store, string key) : base(helper, store, key) { }

        protected override void SetValue(int val)
            => Helper.Set(Store, Key, val);

        protected override int GetValue()
            => Helper.Get(Store, Key, 0);
    }
    
    private sealed class ConfigKeyUInt64 : ConfigKeyBase<ulong>
    {
        public ConfigKeyUInt64(ConfigStoreHelper helper, EConfigStore store, string key) : base(helper, store, key) { }

        protected override void SetValue(ulong val)
            => Helper.Set(Store, Key, val);

        protected override ulong GetValue()
            => Helper.Get(Store, Key, 0UL);
    }
    
    private sealed class ConfigKeyBool : ConfigKeyBase<bool>
    {
        public ConfigKeyBool(ConfigStoreHelper helper, EConfigStore store, string key) : base(helper, store, key) { }

        protected override void SetValue(bool val)
            => Helper.Set(Store, Key, val);

        protected override bool GetValue()
            => Helper.Get(Store, Key, false);
    }
    
    private sealed class ConfigKeyFloat : ConfigKeyBase<float>
    {
        public ConfigKeyFloat(ConfigStoreHelper helper, EConfigStore store, string key) : base(helper, store, key) { }

        protected override void SetValue(float val)
            => Helper.Set(Store, Key, val);

        protected override float GetValue()
            => Helper.Get(Store, Key, 0f);
    }
    
    private sealed class ConfigKeyString : ConfigKeyBase<string>
    {
        public ConfigKeyString(ConfigStoreHelper helper, EConfigStore store, string key) : base(helper, store, key) { }

        protected override void SetValue(string val)
            => Helper.Set(Store, Key, val);

        protected override string GetValue()
            => Helper.Get(Store, Key, "");
    }

    public sealed class ConfigStoreChangedEventArgs(EConfigStore store, string key) : EventArgs
    {
        public EConfigStore Store { get; init; } = store;
        public string Key { get; init; } = key;
    }

    public event EventHandler<ConfigStoreChangedEventArgs>? ConfigStoreChanged;
    
    private readonly IClientConfigStore configStore;
    private readonly IDisposable cbConfigStoreChanged;
    public ConfigStoreHelper(ISteamClient steamClient, ILoggerFactory loggerFactory)
    {
        this.configStore = steamClient.IClientConfigStore;
        this.cbConfigStoreChanged = steamClient.CallbackManager.Register<SteamConfigStoreChanged_t>(OnConfigStoreChanged);
    }

    private void OnConfigStoreChanged(ICallbackHandler handler, SteamConfigStoreChanged_t cb)
    {
        if (cb.ConfigStore == EConfigStore.Invalid)
            return;

        if (string.IsNullOrEmpty(cb.PathToChange))
            return;
        
        ConfigStoreChanged?.Invoke(this, new(cb.ConfigStore, cb.PathToChange));
    }

    public ConfigKeyBase<int> GetKeyInt(EConfigStore store, string key)
        => new ConfigKeyInt(this, store, key);
    
    public ConfigKeyBase<ulong> GetKeyUInt64(EConfigStore store, string key)
        => new ConfigKeyUInt64(this, store, key);
    
    public ConfigKeyBase<bool> GetKeyBool(EConfigStore store, string key)
        => new ConfigKeyBool(this, store, key);
    
    public ConfigKeyBase<float> GetKeyFloat(EConfigStore store, string key)
        => new ConfigKeyFloat(this, store, key);
    
    public ConfigKeyBase<string> GetKeyString(EConfigStore store, string key)
        => new ConfigKeyString(this, store, key);
    
    public bool IsSet(EConfigStore store, string key)
        => configStore.IsSet(store, key);

    public bool Remove(EConfigStore store, string key)
        => configStore.RemoveKey(store, key);

    public int Get(EConfigStore store, string key, int defaultValue = 0)
        => configStore.GetInt(store, key, defaultValue);
    
    public ulong Get(EConfigStore store, string key, ulong defaultValue = 0)
        => configStore.GetUint64(store, key, defaultValue);
    
    public bool Get(EConfigStore store, string key, bool defaultValue = false)
        => configStore.GetBool(store, key, defaultValue);
    
    public float Get(EConfigStore store, string key, float defaultValue = 0)
        => configStore.GetFloat(store, key, defaultValue);
    
    public string Get(EConfigStore store, string key, string defaultValue = "")
        => configStore.GetString(store, key, defaultValue);
    
    public unsafe void Get(EConfigStore store, string key, Span<byte> buf)
    {
        fixed (byte* bptr = buf)
        {
            var attachedBuf = new CUtlBuffer(false, bptr, buf.Length);
            try
            {
                var ret = configStore.GetBinary(store, key, ref attachedBuf);
                if (ret != 0)
                {
                    attachedBuf.TryRead(buf, ret);
                }
            }
            finally
            {
                attachedBuf.Dispose();
            }
        }
        
        
    }
    
    public bool Set(EConfigStore store, string key, int value)
        => configStore.SetInt(store, key, value);
    
    public bool Set(EConfigStore store, string key, ulong value)
        => configStore.SetUint64(store, key, value);
    
    public bool Set(EConfigStore store, string key, bool value)
        => configStore.SetBool(store, key, value);
    
    public bool Set(EConfigStore store, string key, float value)
        => configStore.SetFloat(store, key, value);
    
    public bool Set(EConfigStore store, string key, string value)
        => configStore.SetString(store, key, value);
    
    public bool Set(EConfigStore store, string key, ReadOnlySpan<byte> val)
        => configStore.SetBinary(store, key, val, val.Length);

    public void Flush(bool bIsShuttingDown)
        => configStore.FlushToDisk(bIsShuttingDown);

    public void Dispose()
    {
        cbConfigStoreChanged.Dispose();
    }
}