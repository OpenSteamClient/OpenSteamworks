using System.Diagnostics.CodeAnalysis;
using System.Text;
using Google.Protobuf;
using OpenSteamworks.Protobuf;
using OpenSteamworks.Utils;
using OpenSteamworks.Utils.Enum;

namespace OpenSteamworks.Messaging;

public class ProtoMsg<T> : ProtoMsgBase, ISerializableMsg where T: IMessage<T>, new()
{
    public T Body { get; set; }
    private readonly MessageParser<T> BodyParser;

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
        if (unauthenticated) {
            this.EMsg = EMsg.ServiceMethodCallFromClientNonAuthed;
        } else {
            this.EMsg = EMsg.ServiceMethodCallFromClient;
        }
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
        BodyParser = new MessageParser<T>(() => Body);
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

    public ProtoMsg(byte[] data) : this() {
        using var ms = new MemoryStream(data);
        FillFromStream(ms);
    }

    public static ProtoMsg<T> FromBinary(byte[] data) {
        ProtoMsg<T> msg = new();
        using var ms = new MemoryStream(data);
        msg.FillFromStream(ms);
        return msg;
    }

    [MemberNotNull(nameof(Body))]
    public override void FillFromStream(Stream stream) {
        // Read the header
        base.FillFromStream(stream);

        using var reader = new EndianAwareBinaryReader(stream, Encoding.UTF8, true, Endianness.Little);

        // Read the body
        var body_size = stream.Length - stream.Position;
        byte[] body_binary = reader.ReadBytes((int)body_size);

        // Parse the body
        this.Body = BodyParser.ParseFrom(body_binary);
    }

    public override void Serialize(Stream stream) {
        using var writer = new EndianAwareBinaryWriter(stream, Encoding.UTF8, true, Endianness.Little);

        // Serialize header
        base.Serialize(stream);

        // Serialize body
        writer.Write(this.Body.ToByteArray());
    }

    public override string ToString()
    {
        StringBuilder builder = new();
        builder.AppendLine(string.Format("Printing message {0}, EMsg: {1}", typeof(T).FullName, this.EMsg));
        builder.AppendLine("Header: " + this.Header.ToString());
        builder.AppendLine("Body: " + this.Body.ToString());
        return builder.ToString();
    }

    public byte[] Serialize() {
        using var stream = new MemoryStream();
        Serialize(stream);
        return stream.ToArray();
    }
}