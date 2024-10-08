// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: encrypted_app_ticket.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace OpenSteamworks.Protobuf {

  /// <summary>Holder for reflection information generated from encrypted_app_ticket.proto</summary>
  public static partial class EncryptedAppTicketReflection {

    #region Descriptor
    /// <summary>File descriptor for encrypted_app_ticket.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static EncryptedAppTicketReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChplbmNyeXB0ZWRfYXBwX3RpY2tldC5wcm90bxogZ29vZ2xlL3Byb3RvYnVm",
            "L2Rlc2NyaXB0b3IucHJvdG8irQEKEkVuY3J5cHRlZEFwcFRpY2tldBIZChF0",
            "aWNrZXRfdmVyc2lvbl9ubxgBIAEoDRIbChNjcmNfZW5jcnlwdGVkdGlja2V0",
            "GAIgASgNEhwKFGNiX2VuY3J5cHRlZHVzZXJkYXRhGAMgASgNEicKH2NiX2Vu",
            "Y3J5cHRlZF9hcHBvd25lcnNoaXB0aWNrZXQYBCABKA0SGAoQZW5jcnlwdGVk",
            "X3RpY2tldBgFIAEoDEIfSAGAAQCqAhdPcGVuU3RlYW13b3Jrcy5Qcm90b2J1",
            "Zg=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.Reflection.DescriptorReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::OpenSteamworks.Protobuf.EncryptedAppTicket), global::OpenSteamworks.Protobuf.EncryptedAppTicket.Parser, new[]{ "TicketVersionNo", "CrcEncryptedticket", "CbEncrypteduserdata", "CbEncryptedAppownershipticket", "EncryptedTicket" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class EncryptedAppTicket : pb::IMessage<EncryptedAppTicket>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<EncryptedAppTicket> _parser = new pb::MessageParser<EncryptedAppTicket>(() => new EncryptedAppTicket());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<EncryptedAppTicket> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OpenSteamworks.Protobuf.EncryptedAppTicketReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EncryptedAppTicket() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EncryptedAppTicket(EncryptedAppTicket other) : this() {
      _hasBits0 = other._hasBits0;
      ticketVersionNo_ = other.ticketVersionNo_;
      crcEncryptedticket_ = other.crcEncryptedticket_;
      cbEncrypteduserdata_ = other.cbEncrypteduserdata_;
      cbEncryptedAppownershipticket_ = other.cbEncryptedAppownershipticket_;
      encryptedTicket_ = other.encryptedTicket_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EncryptedAppTicket Clone() {
      return new EncryptedAppTicket(this);
    }

    /// <summary>Field number for the "ticket_version_no" field.</summary>
    public const int TicketVersionNoFieldNumber = 1;
    private readonly static uint TicketVersionNoDefaultValue = 0;

    private uint ticketVersionNo_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint TicketVersionNo {
      get { if ((_hasBits0 & 1) != 0) { return ticketVersionNo_; } else { return TicketVersionNoDefaultValue; } }
      set {
        _hasBits0 |= 1;
        ticketVersionNo_ = value;
      }
    }
    /// <summary>Gets whether the "ticket_version_no" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasTicketVersionNo {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "ticket_version_no" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearTicketVersionNo() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "crc_encryptedticket" field.</summary>
    public const int CrcEncryptedticketFieldNumber = 2;
    private readonly static uint CrcEncryptedticketDefaultValue = 0;

    private uint crcEncryptedticket_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint CrcEncryptedticket {
      get { if ((_hasBits0 & 2) != 0) { return crcEncryptedticket_; } else { return CrcEncryptedticketDefaultValue; } }
      set {
        _hasBits0 |= 2;
        crcEncryptedticket_ = value;
      }
    }
    /// <summary>Gets whether the "crc_encryptedticket" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasCrcEncryptedticket {
      get { return (_hasBits0 & 2) != 0; }
    }
    /// <summary>Clears the value of the "crc_encryptedticket" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearCrcEncryptedticket() {
      _hasBits0 &= ~2;
    }

    /// <summary>Field number for the "cb_encrypteduserdata" field.</summary>
    public const int CbEncrypteduserdataFieldNumber = 3;
    private readonly static uint CbEncrypteduserdataDefaultValue = 0;

    private uint cbEncrypteduserdata_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint CbEncrypteduserdata {
      get { if ((_hasBits0 & 4) != 0) { return cbEncrypteduserdata_; } else { return CbEncrypteduserdataDefaultValue; } }
      set {
        _hasBits0 |= 4;
        cbEncrypteduserdata_ = value;
      }
    }
    /// <summary>Gets whether the "cb_encrypteduserdata" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasCbEncrypteduserdata {
      get { return (_hasBits0 & 4) != 0; }
    }
    /// <summary>Clears the value of the "cb_encrypteduserdata" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearCbEncrypteduserdata() {
      _hasBits0 &= ~4;
    }

    /// <summary>Field number for the "cb_encrypted_appownershipticket" field.</summary>
    public const int CbEncryptedAppownershipticketFieldNumber = 4;
    private readonly static uint CbEncryptedAppownershipticketDefaultValue = 0;

    private uint cbEncryptedAppownershipticket_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint CbEncryptedAppownershipticket {
      get { if ((_hasBits0 & 8) != 0) { return cbEncryptedAppownershipticket_; } else { return CbEncryptedAppownershipticketDefaultValue; } }
      set {
        _hasBits0 |= 8;
        cbEncryptedAppownershipticket_ = value;
      }
    }
    /// <summary>Gets whether the "cb_encrypted_appownershipticket" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasCbEncryptedAppownershipticket {
      get { return (_hasBits0 & 8) != 0; }
    }
    /// <summary>Clears the value of the "cb_encrypted_appownershipticket" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearCbEncryptedAppownershipticket() {
      _hasBits0 &= ~8;
    }

    /// <summary>Field number for the "encrypted_ticket" field.</summary>
    public const int EncryptedTicketFieldNumber = 5;
    private readonly static pb::ByteString EncryptedTicketDefaultValue = pb::ByteString.Empty;

    private pb::ByteString encryptedTicket_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pb::ByteString EncryptedTicket {
      get { return encryptedTicket_ ?? EncryptedTicketDefaultValue; }
      set {
        encryptedTicket_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }
    /// <summary>Gets whether the "encrypted_ticket" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasEncryptedTicket {
      get { return encryptedTicket_ != null; }
    }
    /// <summary>Clears the value of the "encrypted_ticket" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearEncryptedTicket() {
      encryptedTicket_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as EncryptedAppTicket);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(EncryptedAppTicket other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (TicketVersionNo != other.TicketVersionNo) return false;
      if (CrcEncryptedticket != other.CrcEncryptedticket) return false;
      if (CbEncrypteduserdata != other.CbEncrypteduserdata) return false;
      if (CbEncryptedAppownershipticket != other.CbEncryptedAppownershipticket) return false;
      if (EncryptedTicket != other.EncryptedTicket) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (HasTicketVersionNo) hash ^= TicketVersionNo.GetHashCode();
      if (HasCrcEncryptedticket) hash ^= CrcEncryptedticket.GetHashCode();
      if (HasCbEncrypteduserdata) hash ^= CbEncrypteduserdata.GetHashCode();
      if (HasCbEncryptedAppownershipticket) hash ^= CbEncryptedAppownershipticket.GetHashCode();
      if (HasEncryptedTicket) hash ^= EncryptedTicket.GetHashCode();
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
      if (HasTicketVersionNo) {
        output.WriteRawTag(8);
        output.WriteUInt32(TicketVersionNo);
      }
      if (HasCrcEncryptedticket) {
        output.WriteRawTag(16);
        output.WriteUInt32(CrcEncryptedticket);
      }
      if (HasCbEncrypteduserdata) {
        output.WriteRawTag(24);
        output.WriteUInt32(CbEncrypteduserdata);
      }
      if (HasCbEncryptedAppownershipticket) {
        output.WriteRawTag(32);
        output.WriteUInt32(CbEncryptedAppownershipticket);
      }
      if (HasEncryptedTicket) {
        output.WriteRawTag(42);
        output.WriteBytes(EncryptedTicket);
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
      if (HasTicketVersionNo) {
        output.WriteRawTag(8);
        output.WriteUInt32(TicketVersionNo);
      }
      if (HasCrcEncryptedticket) {
        output.WriteRawTag(16);
        output.WriteUInt32(CrcEncryptedticket);
      }
      if (HasCbEncrypteduserdata) {
        output.WriteRawTag(24);
        output.WriteUInt32(CbEncrypteduserdata);
      }
      if (HasCbEncryptedAppownershipticket) {
        output.WriteRawTag(32);
        output.WriteUInt32(CbEncryptedAppownershipticket);
      }
      if (HasEncryptedTicket) {
        output.WriteRawTag(42);
        output.WriteBytes(EncryptedTicket);
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
      if (HasTicketVersionNo) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(TicketVersionNo);
      }
      if (HasCrcEncryptedticket) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(CrcEncryptedticket);
      }
      if (HasCbEncrypteduserdata) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(CbEncrypteduserdata);
      }
      if (HasCbEncryptedAppownershipticket) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(CbEncryptedAppownershipticket);
      }
      if (HasEncryptedTicket) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(EncryptedTicket);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(EncryptedAppTicket other) {
      if (other == null) {
        return;
      }
      if (other.HasTicketVersionNo) {
        TicketVersionNo = other.TicketVersionNo;
      }
      if (other.HasCrcEncryptedticket) {
        CrcEncryptedticket = other.CrcEncryptedticket;
      }
      if (other.HasCbEncrypteduserdata) {
        CbEncrypteduserdata = other.CbEncrypteduserdata;
      }
      if (other.HasCbEncryptedAppownershipticket) {
        CbEncryptedAppownershipticket = other.CbEncryptedAppownershipticket;
      }
      if (other.HasEncryptedTicket) {
        EncryptedTicket = other.EncryptedTicket;
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
            TicketVersionNo = input.ReadUInt32();
            break;
          }
          case 16: {
            CrcEncryptedticket = input.ReadUInt32();
            break;
          }
          case 24: {
            CbEncrypteduserdata = input.ReadUInt32();
            break;
          }
          case 32: {
            CbEncryptedAppownershipticket = input.ReadUInt32();
            break;
          }
          case 42: {
            EncryptedTicket = input.ReadBytes();
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
            TicketVersionNo = input.ReadUInt32();
            break;
          }
          case 16: {
            CrcEncryptedticket = input.ReadUInt32();
            break;
          }
          case 24: {
            CbEncrypteduserdata = input.ReadUInt32();
            break;
          }
          case 32: {
            CbEncryptedAppownershipticket = input.ReadUInt32();
            break;
          }
          case 42: {
            EncryptedTicket = input.ReadBytes();
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
