
using System;

namespace OpenSteamworks.Data;

public struct SteamAPICall<T> where T: struct {
    internal SteamAPICall_t _value;
    public SteamAPICall(SteamAPICall_t val) {
        this._value = val;
    }

    public static implicit operator SteamAPICall<T>(SteamAPICall_t value) {
        return new SteamAPICall<T>(value);
    }

    public static implicit operator SteamAPICall_t(SteamAPICall<T> me) {
        return me._value;
    }

    public override string ToString()
    {
        return _value.ToString();
    }
}