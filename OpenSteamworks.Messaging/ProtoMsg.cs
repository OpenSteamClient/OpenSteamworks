using System.Diagnostics.CodeAnalysis;
using System.Text;
using Google.Protobuf;
using OpenSteamworks.Protobuf;
using OpenSteamworks.Utils;
using OpenSteamworks.Utils.Enum;

namespace OpenSteamworks.Messaging;

public sealed class ProtoMsg<T> : ProtoMsgBase where T: IMessage<T>, new()
{
    public T Body { get; set; }
    private readonly MessageParser<T> bodyParser;

    /// <summary>
    /// Constructs a new ProtoMsg with a specified service method call.
    /// </summary>
    /// <param name="jobName">The JobName of the message</param>
    /// <param name="unauthenticated">If this message is a job AND this argument is set, send this as a NonAuthed service call, otherwise it is sent as a regular service call</param>
    public ProtoMsg(string jobName, bool unauthenticated = false) : this()
    {
        if (string.IsNullOrEmpty(jobName)) {
            throw new NullReferenceException("jobName is null when creating job-based protomsg");
        }

        Header.Steamid = 0;
        this.JobName = jobName;
        this.EMsg = unauthenticated ? EMsg.ServiceMethodCallFromClientNonAuthed : EMsg.ServiceMethodCallFromClient;
    }

    /// <summary>
    /// Constructs a new ProtoMsg with a specified service method call and existing body
    /// </summary>
    /// <param name="jobName">The JobName of the message</param>
    /// <param name="unauthenticated">If this message is a job AND this argument is set, send this as a NonAuthed service call, otherwise it is sent as a regular service call</param>
    public ProtoMsg(T body, string jobName, bool unauthenticated = false) : this(jobName, unauthenticated)
    {
        Body = body;
    }

    public ProtoMsg() {
        Body = new();
        bodyParser = new MessageParser<T>(() => new T());
    }

    /// <summary>
    /// Constructs a new ProtoMsg with the specified EMsg
    /// </summary>
    public ProtoMsg(EMsg eMsg) : this()
    {
        this.EMsg = eMsg;
    }

    /// <summary>
    /// Constructs a new ProtoMsg with the specified EMsg and existing data
    /// </summary>
    public ProtoMsg(EMsg eMsg, T body) : this(eMsg)
    {
        this.Body = body;
    }
    
    /// <summary>
    /// Constructs a new ProtoMsg by deserializing a serialized message
    /// </summary>
    /// <param name="stream"></param>
    public ProtoMsg(Stream stream) : this() {
        Deserialize(stream);
    }
    
    [MemberNotNull(nameof(Body))]
    protected override void DeserializeInternal(EndianAwareBinaryReader reader)
    {
        base.DeserializeInternal(reader);
        this.Body = bodyParser.ParseFrom(RawBody);
    }

    protected override void SerializeInternal(EndianAwareBinaryWriter writer)
    {
        // Serialize body
        RawBody = Body.ToByteArray();
        
        // Base class takes care of the rest
        base.SerializeInternal(writer);
    }

    public override string ToString()
    {
        StringBuilder builder = new();
        builder.AppendLine($"Printing message {typeof(T).FullName}");
        builder.AppendLine($"EMsg: {EMsg}");
        builder.AppendLine("Header: " + Header);
        builder.AppendLine("Body: " + Body);
        return builder.ToString();
    }
}