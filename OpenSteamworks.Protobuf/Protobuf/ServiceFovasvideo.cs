// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: service_fovasvideo.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace OpenSteamworks.Protobuf.WebUI {

  /// <summary>Holder for reflection information generated from service_fovasvideo.proto</summary>
  public static partial class ServiceFovasvideoReflection {

    #region Descriptor
    /// <summary>File descriptor for service_fovasvideo.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ServiceFovasvideoReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChhzZXJ2aWNlX2ZvdmFzdmlkZW8ucHJvdG8aIGdvb2dsZS9wcm90b2J1Zi9k",
            "ZXNjcmlwdG9yLnByb3RvIlEKKENGb3Zhc1ZpZGVvX0NsaWVudEdldE9QRlNl",
            "dHRpbmdzX1JlcXVlc3QSDgoGYXBwX2lkGAEgASgNEhUKDWNsaWVudF9jZWxs",
            "aWQYAiABKA0iUQopQ0ZvdmFzVmlkZW9fQ2xpZW50R2V0T1BGU2V0dGluZ3Nf",
            "UmVzcG9uc2USDgoGYXBwX2lkGAEgASgNEhQKDG9wZl9zZXR0aW5ncxgCIAEo",
            "CTJ7CgpGb3Zhc1ZpZGVvEm0KFENsaWVudEdldE9QRlNldHRpbmdzEikuQ0Zv",
            "dmFzVmlkZW9fQ2xpZW50R2V0T1BGU2V0dGluZ3NfUmVxdWVzdBoqLkNGb3Zh",
            "c1ZpZGVvX0NsaWVudEdldE9QRlNldHRpbmdzX1Jlc3BvbnNlQiCqAh1PcGVu",
            "U3RlYW13b3Jrcy5Qcm90b2J1Zi5XZWJVSQ=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::OpenSteamworks.Protobuf.WebUI.CFovasVideo_ClientGetOPFSettings_Request), global::OpenSteamworks.Protobuf.WebUI.CFovasVideo_ClientGetOPFSettings_Request.Parser, new[]{ "AppId", "ClientCellid" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::OpenSteamworks.Protobuf.WebUI.CFovasVideo_ClientGetOPFSettings_Response), global::OpenSteamworks.Protobuf.WebUI.CFovasVideo_ClientGetOPFSettings_Response.Parser, new[]{ "AppId", "OpfSettings" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class CFovasVideo_ClientGetOPFSettings_Request : pb::IMessage<CFovasVideo_ClientGetOPFSettings_Request>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<CFovasVideo_ClientGetOPFSettings_Request> _parser = new pb::MessageParser<CFovasVideo_ClientGetOPFSettings_Request>(() => new CFovasVideo_ClientGetOPFSettings_Request());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<CFovasVideo_ClientGetOPFSettings_Request> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OpenSteamworks.Protobuf.WebUI.ServiceFovasvideoReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CFovasVideo_ClientGetOPFSettings_Request() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CFovasVideo_ClientGetOPFSettings_Request(CFovasVideo_ClientGetOPFSettings_Request other) : this() {
      _hasBits0 = other._hasBits0;
      appId_ = other.appId_;
      clientCellid_ = other.clientCellid_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CFovasVideo_ClientGetOPFSettings_Request Clone() {
      return new CFovasVideo_ClientGetOPFSettings_Request(this);
    }

    /// <summary>Field number for the "app_id" field.</summary>
    public const int AppIdFieldNumber = 1;
    private readonly static uint AppIdDefaultValue = 0;

    private uint appId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint AppId {
      get { if ((_hasBits0 & 1) != 0) { return appId_; } else { return AppIdDefaultValue; } }
      set {
        _hasBits0 |= 1;
        appId_ = value;
      }
    }
    /// <summary>Gets whether the "app_id" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasAppId {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "app_id" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearAppId() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "client_cellid" field.</summary>
    public const int ClientCellidFieldNumber = 2;
    private readonly static uint ClientCellidDefaultValue = 0;

    private uint clientCellid_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint ClientCellid {
      get { if ((_hasBits0 & 2) != 0) { return clientCellid_; } else { return ClientCellidDefaultValue; } }
      set {
        _hasBits0 |= 2;
        clientCellid_ = value;
      }
    }
    /// <summary>Gets whether the "client_cellid" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasClientCellid {
      get { return (_hasBits0 & 2) != 0; }
    }
    /// <summary>Clears the value of the "client_cellid" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearClientCellid() {
      _hasBits0 &= ~2;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as CFovasVideo_ClientGetOPFSettings_Request);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(CFovasVideo_ClientGetOPFSettings_Request other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (AppId != other.AppId) return false;
      if (ClientCellid != other.ClientCellid) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (HasAppId) hash ^= AppId.GetHashCode();
      if (HasClientCellid) hash ^= ClientCellid.GetHashCode();
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
      if (HasAppId) {
        output.WriteRawTag(8);
        output.WriteUInt32(AppId);
      }
      if (HasClientCellid) {
        output.WriteRawTag(16);
        output.WriteUInt32(ClientCellid);
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
      if (HasAppId) {
        output.WriteRawTag(8);
        output.WriteUInt32(AppId);
      }
      if (HasClientCellid) {
        output.WriteRawTag(16);
        output.WriteUInt32(ClientCellid);
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
      if (HasAppId) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(AppId);
      }
      if (HasClientCellid) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ClientCellid);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(CFovasVideo_ClientGetOPFSettings_Request other) {
      if (other == null) {
        return;
      }
      if (other.HasAppId) {
        AppId = other.AppId;
      }
      if (other.HasClientCellid) {
        ClientCellid = other.ClientCellid;
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
            AppId = input.ReadUInt32();
            break;
          }
          case 16: {
            ClientCellid = input.ReadUInt32();
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
            AppId = input.ReadUInt32();
            break;
          }
          case 16: {
            ClientCellid = input.ReadUInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class CFovasVideo_ClientGetOPFSettings_Response : pb::IMessage<CFovasVideo_ClientGetOPFSettings_Response>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<CFovasVideo_ClientGetOPFSettings_Response> _parser = new pb::MessageParser<CFovasVideo_ClientGetOPFSettings_Response>(() => new CFovasVideo_ClientGetOPFSettings_Response());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<CFovasVideo_ClientGetOPFSettings_Response> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OpenSteamworks.Protobuf.WebUI.ServiceFovasvideoReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CFovasVideo_ClientGetOPFSettings_Response() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CFovasVideo_ClientGetOPFSettings_Response(CFovasVideo_ClientGetOPFSettings_Response other) : this() {
      _hasBits0 = other._hasBits0;
      appId_ = other.appId_;
      opfSettings_ = other.opfSettings_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CFovasVideo_ClientGetOPFSettings_Response Clone() {
      return new CFovasVideo_ClientGetOPFSettings_Response(this);
    }

    /// <summary>Field number for the "app_id" field.</summary>
    public const int AppIdFieldNumber = 1;
    private readonly static uint AppIdDefaultValue = 0;

    private uint appId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint AppId {
      get { if ((_hasBits0 & 1) != 0) { return appId_; } else { return AppIdDefaultValue; } }
      set {
        _hasBits0 |= 1;
        appId_ = value;
      }
    }
    /// <summary>Gets whether the "app_id" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasAppId {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "app_id" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearAppId() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "opf_settings" field.</summary>
    public const int OpfSettingsFieldNumber = 2;
    private readonly static string OpfSettingsDefaultValue = "";

    private string opfSettings_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string OpfSettings {
      get { return opfSettings_ ?? OpfSettingsDefaultValue; }
      set {
        opfSettings_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }
    /// <summary>Gets whether the "opf_settings" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasOpfSettings {
      get { return opfSettings_ != null; }
    }
    /// <summary>Clears the value of the "opf_settings" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearOpfSettings() {
      opfSettings_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as CFovasVideo_ClientGetOPFSettings_Response);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(CFovasVideo_ClientGetOPFSettings_Response other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (AppId != other.AppId) return false;
      if (OpfSettings != other.OpfSettings) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (HasAppId) hash ^= AppId.GetHashCode();
      if (HasOpfSettings) hash ^= OpfSettings.GetHashCode();
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
      if (HasAppId) {
        output.WriteRawTag(8);
        output.WriteUInt32(AppId);
      }
      if (HasOpfSettings) {
        output.WriteRawTag(18);
        output.WriteString(OpfSettings);
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
      if (HasAppId) {
        output.WriteRawTag(8);
        output.WriteUInt32(AppId);
      }
      if (HasOpfSettings) {
        output.WriteRawTag(18);
        output.WriteString(OpfSettings);
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
      if (HasAppId) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(AppId);
      }
      if (HasOpfSettings) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(OpfSettings);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(CFovasVideo_ClientGetOPFSettings_Response other) {
      if (other == null) {
        return;
      }
      if (other.HasAppId) {
        AppId = other.AppId;
      }
      if (other.HasOpfSettings) {
        OpfSettings = other.OpfSettings;
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
            AppId = input.ReadUInt32();
            break;
          }
          case 18: {
            OpfSettings = input.ReadString();
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
            AppId = input.ReadUInt32();
            break;
          }
          case 18: {
            OpfSettings = input.ReadString();
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
