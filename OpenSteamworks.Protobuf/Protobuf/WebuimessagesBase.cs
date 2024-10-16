// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: webuimessages_base.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace OpenSteamworks.Protobuf {

  /// <summary>Holder for reflection information generated from webuimessages_base.proto</summary>
  public static partial class WebuimessagesBaseReflection {

    #region Descriptor
    /// <summary>File descriptor for webuimessages_base.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static WebuimessagesBaseReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Chh3ZWJ1aW1lc3NhZ2VzX2Jhc2UucHJvdG8aC2VudW1zLnByb3RvGhhzdGVh",
            "bW1lc3NhZ2VzX2Jhc2UucHJvdG8aIGdvb2dsZS9wcm90b2J1Zi9kZXNjcmlw",
            "dG9yLnByb3RvIhEKD1dlYlVJTm9SZXNwb25zZSqYAQoURUNsaWVudEV4ZWN1",
            "dGlvblNpdGUSHwobRUNsaWVudEV4ZWN1dGlvblNpdGVJbnZhbGlkEAASHwob",
            "RUNsaWVudEV4ZWN1dGlvblNpdGVTdGVhbVVJEAESIQodRUNsaWVudEV4ZWN1",
            "dGlvblNpdGVDbGllbnRkbGwQAhIbChdFQ2xpZW50RXhlY3V0aW9uU2l0ZUFu",
            "eRADOnsKHHdlYnVpX3NlcnZpY2VfZXhlY3V0aW9uX3NpdGUSHy5nb29nbGUu",
            "cHJvdG9idWYuU2VydmljZU9wdGlvbnMY8KIEIAEoDjIVLkVDbGllbnRFeGVj",
            "dXRpb25TaXRlOhtFQ2xpZW50RXhlY3V0aW9uU2l0ZVN0ZWFtVUk6eQobd2Vi",
            "dWlfbWV0aG9kX2V4ZWN1dGlvbl9zaXRlEh4uZ29vZ2xlLnByb3RvYnVmLk1l",
            "dGhvZE9wdGlvbnMY8KIEIAEoDjIVLkVDbGllbnRFeGVjdXRpb25TaXRlOhtF",
            "Q2xpZW50RXhlY3V0aW9uU2l0ZUludmFsaWRCH0gBgAEBqgIXT3BlblN0ZWFt",
            "d29ya3MuUHJvdG9idWY="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::OpenSteamworks.Protobuf.EnumsReflection.Descriptor, global::OpenSteamworks.Protobuf.SteammessagesBaseReflection.Descriptor, global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::OpenSteamworks.Protobuf.EClientExecutionSite), }, new pb::Extension[] { WebuimessagesBaseExtensions.WebuiServiceExecutionSite, WebuimessagesBaseExtensions.WebuiMethodExecutionSite }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::OpenSteamworks.Protobuf.WebUINoResponse), global::OpenSteamworks.Protobuf.WebUINoResponse.Parser, null, null, null, null, null)
          }));
    }
    #endregion

  }
  /// <summary>Holder for extension identifiers generated from the top level of webuimessages_base.proto</summary>
  public static partial class WebuimessagesBaseExtensions {
    public static readonly pb::Extension<global::Google.Protobuf.Reflection.ServiceOptions, global::OpenSteamworks.Protobuf.EClientExecutionSite> WebuiServiceExecutionSite =
      new pb::Extension<global::Google.Protobuf.Reflection.ServiceOptions, global::OpenSteamworks.Protobuf.EClientExecutionSite>(70000, pb::FieldCodec.ForEnum(560000, x => (int) x, x => (global::OpenSteamworks.Protobuf.EClientExecutionSite) x, global::OpenSteamworks.Protobuf.EClientExecutionSite.SteamUi));
    public static readonly pb::Extension<global::Google.Protobuf.Reflection.MethodOptions, global::OpenSteamworks.Protobuf.EClientExecutionSite> WebuiMethodExecutionSite =
      new pb::Extension<global::Google.Protobuf.Reflection.MethodOptions, global::OpenSteamworks.Protobuf.EClientExecutionSite>(70000, pb::FieldCodec.ForEnum(560000, x => (int) x, x => (global::OpenSteamworks.Protobuf.EClientExecutionSite) x, global::OpenSteamworks.Protobuf.EClientExecutionSite.Invalid));
  }

  #region Enums
  public enum EClientExecutionSite {
    [pbr::OriginalName("EClientExecutionSiteInvalid")] Invalid = 0,
    [pbr::OriginalName("EClientExecutionSiteSteamUI")] SteamUi = 1,
    [pbr::OriginalName("EClientExecutionSiteClientdll")] Clientdll = 2,
    [pbr::OriginalName("EClientExecutionSiteAny")] Any = 3,
  }

  #endregion

  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class WebUINoResponse : pb::IMessage<WebUINoResponse>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<WebUINoResponse> _parser = new pb::MessageParser<WebUINoResponse>(() => new WebUINoResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<WebUINoResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OpenSteamworks.Protobuf.WebuimessagesBaseReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public WebUINoResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public WebUINoResponse(WebUINoResponse other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public WebUINoResponse Clone() {
      return new WebUINoResponse(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as WebUINoResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(WebUINoResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
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
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(WebUINoResponse other) {
      if (other == null) {
        return;
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
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
