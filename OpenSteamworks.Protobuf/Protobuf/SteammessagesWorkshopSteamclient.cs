// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: steammessages_workshop.steamclient.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace OpenSteamworks.Protobuf {

  /// <summary>Holder for reflection information generated from steammessages_workshop.steamclient.proto</summary>
  public static partial class SteammessagesWorkshopSteamclientReflection {

    #region Descriptor
    /// <summary>File descriptor for steammessages_workshop.steamclient.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SteammessagesWorkshopSteamclientReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CihzdGVhbW1lc3NhZ2VzX3dvcmtzaG9wLnN0ZWFtY2xpZW50LnByb3RvGiBn",
            "b29nbGUvcHJvdG9idWYvZGVzY3JpcHRvci5wcm90bxoYc3RlYW1tZXNzYWdl",
            "c19iYXNlLnByb3RvGixzdGVhbW1lc3NhZ2VzX3VuaWZpZWRfYmFzZS5zdGVh",
            "bWNsaWVudC5wcm90byIwCh9DV29ya3Nob3BfR2V0RVVMQVN0YXR1c19SZXF1",
            "ZXN0Eg0KBWFwcGlkGAEgASgNInUKIENXb3Jrc2hvcF9HZXRFVUxBU3RhdHVz",
            "X1Jlc3BvbnNlEg8KB3ZlcnNpb24YASABKA0SGAoQdGltZXN0YW1wX2FjdGlv",
            "bhgCIAEoDRIQCghhY2NlcHRlZBgDIAEoCBIUCgxuZWVkc19hY3Rpb24YBCAB",
            "KAgyYAoIV29ya3Nob3ASVAoNR2V0RVVMQVN0YXR1cxIgLkNXb3Jrc2hvcF9H",
            "ZXRFVUxBU3RhdHVzX1JlcXVlc3QaIS5DV29ya3Nob3BfR2V0RVVMQVN0YXR1",
            "c19SZXNwb25zZUIdgAEBqgIXT3BlblN0ZWFtd29ya3MuUHJvdG9idWY="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor, global::OpenSteamworks.Protobuf.SteammessagesBaseReflection.Descriptor, global::OpenSteamworks.Protobuf.SteammessagesUnifiedBaseSteamclientReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::OpenSteamworks.Protobuf.CWorkshop_GetEULAStatus_Request), global::OpenSteamworks.Protobuf.CWorkshop_GetEULAStatus_Request.Parser, new[]{ "Appid" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::OpenSteamworks.Protobuf.CWorkshop_GetEULAStatus_Response), global::OpenSteamworks.Protobuf.CWorkshop_GetEULAStatus_Response.Parser, new[]{ "Version", "TimestampAction", "Accepted", "NeedsAction" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class CWorkshop_GetEULAStatus_Request : pb::IMessage<CWorkshop_GetEULAStatus_Request>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<CWorkshop_GetEULAStatus_Request> _parser = new pb::MessageParser<CWorkshop_GetEULAStatus_Request>(() => new CWorkshop_GetEULAStatus_Request());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<CWorkshop_GetEULAStatus_Request> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OpenSteamworks.Protobuf.SteammessagesWorkshopSteamclientReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CWorkshop_GetEULAStatus_Request() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CWorkshop_GetEULAStatus_Request(CWorkshop_GetEULAStatus_Request other) : this() {
      _hasBits0 = other._hasBits0;
      appid_ = other.appid_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CWorkshop_GetEULAStatus_Request Clone() {
      return new CWorkshop_GetEULAStatus_Request(this);
    }

    /// <summary>Field number for the "appid" field.</summary>
    public const int AppidFieldNumber = 1;
    private readonly static uint AppidDefaultValue = 0;

    private uint appid_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint Appid {
      get { if ((_hasBits0 & 1) != 0) { return appid_; } else { return AppidDefaultValue; } }
      set {
        _hasBits0 |= 1;
        appid_ = value;
      }
    }
    /// <summary>Gets whether the "appid" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasAppid {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "appid" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearAppid() {
      _hasBits0 &= ~1;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as CWorkshop_GetEULAStatus_Request);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(CWorkshop_GetEULAStatus_Request other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Appid != other.Appid) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (HasAppid) hash ^= Appid.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (HasAppid) {
        output.WriteRawTag(8);
        output.WriteUInt32(Appid);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (HasAppid) {
        output.WriteRawTag(8);
        output.WriteUInt32(Appid);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (HasAppid) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Appid);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(CWorkshop_GetEULAStatus_Request other) {
      if (other == null) {
        return;
      }
      if (other.HasAppid) {
        Appid = other.Appid;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Appid = input.ReadUInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            Appid = input.ReadUInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class CWorkshop_GetEULAStatus_Response : pb::IMessage<CWorkshop_GetEULAStatus_Response>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<CWorkshop_GetEULAStatus_Response> _parser = new pb::MessageParser<CWorkshop_GetEULAStatus_Response>(() => new CWorkshop_GetEULAStatus_Response());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<CWorkshop_GetEULAStatus_Response> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OpenSteamworks.Protobuf.SteammessagesWorkshopSteamclientReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CWorkshop_GetEULAStatus_Response() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CWorkshop_GetEULAStatus_Response(CWorkshop_GetEULAStatus_Response other) : this() {
      _hasBits0 = other._hasBits0;
      version_ = other.version_;
      timestampAction_ = other.timestampAction_;
      accepted_ = other.accepted_;
      needsAction_ = other.needsAction_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CWorkshop_GetEULAStatus_Response Clone() {
      return new CWorkshop_GetEULAStatus_Response(this);
    }

    /// <summary>Field number for the "version" field.</summary>
    public const int VersionFieldNumber = 1;
    private readonly static uint VersionDefaultValue = 0;

    private uint version_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint Version {
      get { if ((_hasBits0 & 1) != 0) { return version_; } else { return VersionDefaultValue; } }
      set {
        _hasBits0 |= 1;
        version_ = value;
      }
    }
    /// <summary>Gets whether the "version" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasVersion {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "version" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearVersion() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "timestamp_action" field.</summary>
    public const int TimestampActionFieldNumber = 2;
    private readonly static uint TimestampActionDefaultValue = 0;

    private uint timestampAction_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint TimestampAction {
      get { if ((_hasBits0 & 2) != 0) { return timestampAction_; } else { return TimestampActionDefaultValue; } }
      set {
        _hasBits0 |= 2;
        timestampAction_ = value;
      }
    }
    /// <summary>Gets whether the "timestamp_action" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasTimestampAction {
      get { return (_hasBits0 & 2) != 0; }
    }
    /// <summary>Clears the value of the "timestamp_action" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearTimestampAction() {
      _hasBits0 &= ~2;
    }

    /// <summary>Field number for the "accepted" field.</summary>
    public const int AcceptedFieldNumber = 3;
    private readonly static bool AcceptedDefaultValue = false;

    private bool accepted_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Accepted {
      get { if ((_hasBits0 & 4) != 0) { return accepted_; } else { return AcceptedDefaultValue; } }
      set {
        _hasBits0 |= 4;
        accepted_ = value;
      }
    }
    /// <summary>Gets whether the "accepted" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasAccepted {
      get { return (_hasBits0 & 4) != 0; }
    }
    /// <summary>Clears the value of the "accepted" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearAccepted() {
      _hasBits0 &= ~4;
    }

    /// <summary>Field number for the "needs_action" field.</summary>
    public const int NeedsActionFieldNumber = 4;
    private readonly static bool NeedsActionDefaultValue = false;

    private bool needsAction_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool NeedsAction {
      get { if ((_hasBits0 & 8) != 0) { return needsAction_; } else { return NeedsActionDefaultValue; } }
      set {
        _hasBits0 |= 8;
        needsAction_ = value;
      }
    }
    /// <summary>Gets whether the "needs_action" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasNeedsAction {
      get { return (_hasBits0 & 8) != 0; }
    }
    /// <summary>Clears the value of the "needs_action" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearNeedsAction() {
      _hasBits0 &= ~8;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as CWorkshop_GetEULAStatus_Response);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(CWorkshop_GetEULAStatus_Response other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Version != other.Version) return false;
      if (TimestampAction != other.TimestampAction) return false;
      if (Accepted != other.Accepted) return false;
      if (NeedsAction != other.NeedsAction) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (HasVersion) hash ^= Version.GetHashCode();
      if (HasTimestampAction) hash ^= TimestampAction.GetHashCode();
      if (HasAccepted) hash ^= Accepted.GetHashCode();
      if (HasNeedsAction) hash ^= NeedsAction.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (HasVersion) {
        output.WriteRawTag(8);
        output.WriteUInt32(Version);
      }
      if (HasTimestampAction) {
        output.WriteRawTag(16);
        output.WriteUInt32(TimestampAction);
      }
      if (HasAccepted) {
        output.WriteRawTag(24);
        output.WriteBool(Accepted);
      }
      if (HasNeedsAction) {
        output.WriteRawTag(32);
        output.WriteBool(NeedsAction);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (HasVersion) {
        output.WriteRawTag(8);
        output.WriteUInt32(Version);
      }
      if (HasTimestampAction) {
        output.WriteRawTag(16);
        output.WriteUInt32(TimestampAction);
      }
      if (HasAccepted) {
        output.WriteRawTag(24);
        output.WriteBool(Accepted);
      }
      if (HasNeedsAction) {
        output.WriteRawTag(32);
        output.WriteBool(NeedsAction);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (HasVersion) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Version);
      }
      if (HasTimestampAction) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(TimestampAction);
      }
      if (HasAccepted) {
        size += 1 + 1;
      }
      if (HasNeedsAction) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(CWorkshop_GetEULAStatus_Response other) {
      if (other == null) {
        return;
      }
      if (other.HasVersion) {
        Version = other.Version;
      }
      if (other.HasTimestampAction) {
        TimestampAction = other.TimestampAction;
      }
      if (other.HasAccepted) {
        Accepted = other.Accepted;
      }
      if (other.HasNeedsAction) {
        NeedsAction = other.NeedsAction;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Version = input.ReadUInt32();
            break;
          }
          case 16: {
            TimestampAction = input.ReadUInt32();
            break;
          }
          case 24: {
            Accepted = input.ReadBool();
            break;
          }
          case 32: {
            NeedsAction = input.ReadBool();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            Version = input.ReadUInt32();
            break;
          }
          case 16: {
            TimestampAction = input.ReadUInt32();
            break;
          }
          case 24: {
            Accepted = input.ReadBool();
            break;
          }
          case 32: {
            NeedsAction = input.ReadBool();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
