using System.Text;
using OpenSteamworks.Protobuf;
using OpenSteamworks.Messaging.Structs;
using OpenSteamworks.Utils;
using OpenSteamworks.Utils.Enum;

namespace OpenSteamworks.Messaging;

public static class EMsgUtil {
    public const uint PROTOBUF_MASK = 0x80000000;

    /// <summary>
    /// Check if this eMsg is protobuf or not
    /// </summary>
    public static bool IsProtoBuf(uint msg)
    {
        return (msg & PROTOBUF_MASK) > 0;
    }

    /// <summary>
    /// Get the "true" EMsg, stripping off the protobuf mask if it's set
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public static EMsg GetTrueEMsg(uint msg) {
        if (IsProtoBuf(msg)) {
            return (EMsg)(~PROTOBUF_MASK & msg);
        } else {
            return (EMsg)msg;
        }
    }

    /// <summary>
    /// Make this EMsg into it's serialized form.
    /// </summary>
    public static uint Make(EMsg msg, bool proto = false) {
        if (proto) {
            return PROTOBUF_MASK | (uint)msg;
        }

        return (uint)msg;
    }
}