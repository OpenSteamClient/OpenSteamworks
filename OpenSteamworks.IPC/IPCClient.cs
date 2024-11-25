using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenSteamworks.Extensions;
using OpenSteamworks.Messaging;
using OpenSteamworks.Data.Structs;
using System.Globalization;
using OpenSteamworks.Utils;
using System.Diagnostics;
using System.Linq;
using System.Net;
using OpenSteamClient.Logging;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.IPC;

/// <summary>
/// Represents the base of a connection to a remote IPC service, such as the Steam3Master or SteamClientService.
/// </summary>
// TODO: Support different kinds of pipes, such as shared memory pipes, win32 pipes, in-process pipes and so on.
// Which also means, TODO: Windows support.
public abstract class IPCClient {
    
    public int RemotePID { get; private set; }
    public uint IPCCallCount { get; private set; } = 0;

    private readonly Socket tcpSocket;
    private bool hasCallbacks = false;
    private readonly ILogger logger;
    public IPCClient(ILoggerFactory loggerFactory, string ipcService)
    {
        logger = loggerFactory.CreateLogger($"IPCClient-{ipcService}");
        
        tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        tcpSocket.NoDelay = true;
        tcpSocket.Blocking = true;
        
        IPEndPoint ep = GetEndPointFromName(ipcService);
        
        logger.Info("Connecting to " + ep.ToString());
        tcpSocket.Connect(ep);
        logger.Info("Connected to " + ep.ToString());
        
        ConnectToSteamPipe(out uint hostPid);
    }

    private void HandleMessageData(ReadOnlyMemory<byte> msg)
    {
        
    }

    protected virtual void HandleMessage(EIPCResponseCode responseCode, ReadOnlySpan<byte> msg)
    {
        
    }
    
    private void HandleData(byte[] partial)
    {
        logger.Debug("Got data from server " + string.Join(" ", partial));
        if (HandlePartial(partial, out byte[]? msg))
        {
            logger.Debug("Full msg: " + string.Join(" ", msg));
            using var stream = new MemoryStream(msg);
            using var reader = new EndianAwareBinaryReader(stream, OpenSteamworks.Utils.Enum.Endianness.Little);

            var len = reader.ReadUInt32();
            var cmd = reader.ReadByte();
            if (!Enum.IsDefined(typeof(EIPCResponseCode), cmd))
            {
                logger.Debug("Unsupported response code " + cmd);
                return;
                //throw new InvalidOperationException("Unsupported response code " + cmd);
            }

            try
            {
                HandleMessage((IPCResponseCode)cmd);
            }
            catch (System.Exception e)
            {
                logger.Debug("Got error while handling message:");
                logger.Debug(e.ToString());
                if (!pipeIsConnected) {
                    logger.Debug("Error is fatal");

                    // This has to be done like this, otherwise it will hang forever
                    Task.Run(() => this.Shutdown());
                }
            }
        }
    }
    
    private void HandleMessage(IPCResponseCode code)
    {
        switch (code)
        {
            case IPCResponseCode.CallbacksAvailable: // S: 1 0 0 0 7
                var cb = SendAndWaitForResponse(IPCCommandCode.SerializeCallbacks, []); // C: 1 0 0 0 2
                // S: 17 0 0 0 2 1 0 0 0 209 161 16 0 4 0 0 0 1 0 0 0
                // S: 13 0 0 0 2 0 0 0 0 0 0 0 0 0 0 0 0
                // S: 1 0 0 0 7
                logger.Debug("Got CB " + ReadCB(cb));
                while (tcpClient.Client.Poll(TimeSpan.FromMilliseconds(56), SelectMode.SelectRead))
                {
                    logger.Debug("poll success, avail: " + tcpClient.Available);
                    if (tcpClient.Available < 13) {
                        break;
                    }

                    var cb2 = WaitForMessageOfLength(13); // S: 13 0 0 0 2 0 0 0 0 0 0 0 0 0 0 0 0
                    if (cb2[4] == (byte)IPCCommandCode.SerializeCallbacks) {
                        logger.Debug("More?");
                        var ca2 = WaitForMessageOfLength(5);
                        if (ca2[4] == (byte)IPCResponseCode.CallbacksAvailable) {
                            logger.Debug("More callbacks available");

                            cb2 = WaitForMessageOfLength(13);
                            logger.Debug("Got CB2 " + ReadCB(cb2));
                        } else {
                            logger.Debug("No");
                            break;
                        }
                    } else {
                        
                    }
                }

                break;
            default:
                logger.Debug("Got unsupported command " + code);
                break;
        }
    }

    private int ReadCB(byte[] cb) {
        using var reader = new EndianAwareBinaryReader(new MemoryStream(cb), Utils.Enum.Endianness.Little);
        var firstByte = reader.ReadByte();
        if (firstByte != 2) {
            logger.Debug("CB unknown first byte " + firstByte);
        }

        var steamUser = reader.ReadInt32();
        var callbackID = reader.ReadInt32();
        var len = reader.ReadUInt32();
        var callbackData = reader.ReadBytes((int)len);
        return callbackID;
    }

    private IPEndPoint GetEndPointFromName(string ipcName) {
        string? overrideIP = Environment.GetEnvironmentVariable($"{ipcName}_{Environment.ProcessId}");
        if (!string.IsNullOrEmpty(overrideIP)) {
            if (IPEndPoint.TryParse(overrideIP, out IPEndPoint? endPoint)) {
                return endPoint;
            }

        } else {
            overrideIP = Environment.GetEnvironmentVariable(ipcName);
            if (!string.IsNullOrEmpty(overrideIP)) {
                if (IPEndPoint.TryParse(overrideIP, out IPEndPoint? endPoint)) {
                    return endPoint;
                }
            }
        }

        if (ipcName == "Steam3Master") {
            return new IPEndPoint(IPAddress.Loopback, 57343);
        } else if (ipcName == "SteamClientService") {
            return new IPEndPoint(IPAddress.Loopback, 57344);
        }

        throw new ArgumentException("Unknown IPC service " + ipcName, nameof(ipcName));
    }

    public void ReleaseUser(HSteamUser hUser) {
        uint user = (uint)(int)hUser;
        using (var stream = new MemoryStream()) {
            var writer = new EndianAwareBinaryWriter(stream);
            writer.WriteUInt32(user);
            SendAndWaitForResponse(IPCCommandCode.ReleaseGlobalUser, stream.ToArray());
        }
    }

    public void ResetIPCCallCount() {
        IPCCallCount = 0;
    }

    public void ConnectToSteamPipe(out uint hostPid) {
        hostPid = 0;
        logger.Info("Connect to pipe");
        using (var stream = new MemoryStream()) {
            var writer = new EndianAwareBinaryWriter(stream);
            // | Success | ProcID | ThreadID |
            writer.WriteUInt32(1);
            writer.WriteUInt32((uint)Environment.ProcessId);
            
            if (OperatingSystem.IsWindows()) {
                [DllImport("kernel32.dll")]
                static extern int GetCurrentThreadId();
                writer.WriteUInt32((uint)GetCurrentThreadId());
            } else if (OperatingSystem.IsLinux()) {
                [DllImport("libc")]
                static extern int gettid();
                writer.WriteUInt32((uint)gettid());
            } else {
                throw new PlatformNotSupportedException();
            }

            var resp2 = SendAndWaitForResponse(IPCCommandCode.ConnectPipe, stream.ToArray());
            using (var response = new MemoryStream(resp2)) {
                var reader = new EndianAwareBinaryReader(response);
                // Length (12) | HostPID | HostThreadID | Seed |
                Trace.Assert(reader.ReadUInt32() == 12);
                hostPid = reader.ReadUInt32();
                var hosttid = reader.ReadUInt32();
                var seed = reader.ReadUInt32();
                logger.Info($"Got host pid: {hostPid}, host tid: {hosttid}, seed: {seed}");
                ThrowIfInvalidHostProcess((int)hostPid, (int)hosttid);
                pipeIsConnected = true;
            }
        }
    }

    private void ThrowIfInvalidHostProcess(int pid, int tid) {
        var proc = Process.GetProcesses().First(p => p.Id == pid);
        if (proc == null) {
            throw new Exception("Process " + pid + " does not exist!");
        }

        for (int i = 0; i < proc.Threads.Count; i++)
        {
            var thrd = proc.Threads[i];
            if (thrd.Id == tid) {
                return;
            }
        }

        throw new Exception($"Thread {tid} in process {pid} ({proc.ProcessName}) does not exist!");
    }

    public HSteamUser ConnectToGlobalUser() {
        logger.Info("Connect to user");

        // | GlobalUserType |
        uint hUser;
        var resp = SendAndWaitForResponse(IPCCommandCode.ConnectToGlobalUser, new byte[] {2});
        using (var response = new MemoryStream(resp)) {
            var reader = new EndianAwareBinaryReader(response);

            reader.ReadByte();
            hUser = reader.ReadUInt32();
            if (hUser < 1) {
                throw new Exception($"ConnectToGlobalUser returned invalid HSteamUserEngine={hUser}");
            }

            logger.Info("Got HSteamUser " + hUser);
        }

        return (int)hUser;
    }

    public byte[] SendAndWaitForResponse(IPCCommandCode command, byte[] data) {
        lock (serializeLock)
        {
            var serialized = Serialize(command, data);
            Send(serialized);
            logger.Debug($"sent {data.Length} bytes as {command}, waiting for response");
            var resp = WaitForResponseTo(command);

            if (command == IPCCommandCode.Interface) {
                IPCCallCount++;
            }

            return resp;
        }
    }

    private byte[] Serialize(IPCCommandCode command, byte[] data) {

        var hdr = new ClientMsgHeader() { DataLength = (uint)data.Length, Command = command }.Serialize();
        byte[] bytes;
        using (var stream = new MemoryStream()) {
            stream.Write(hdr);
            stream.Write(data);
            bytes = stream.ToArray();
        }

        return bytes;
    }

    private byte[] WaitForResponseTo(IPCCommandCode sentCommand) {
        switch (sentCommand)
        {
            case IPCCommandCode.Interface:
            case IPCCommandCode.SerializeCallbacks:
            case IPCCommandCode.ConnectToGlobalUser:
                return WaitForMessage();
            case IPCCommandCode.ConnectPipe:
                return WaitForMessageOfLength(16);
            case IPCCommandCode.TerminatePipe:
            default:
                throw new InvalidOperationException("Unhandled IPCCommandCode (or received error)");
        }

        throw new UnreachableException();
    }

    private SpinLock socketLock = new();

    public void Shutdown() {
        this.tcpClient.Close();
    }

    private void Send(byte[] buffer) {
        bool gotLock = false;
        try
        {
            socketLock.Enter(ref gotLock);
            var stream = tcpClient.GetStream();
            stream.Write(buffer);
            stream.Flush();
        }
        finally
        {
            if (gotLock) socketLock.Exit();
        }
    }

    private byte[] WaitForMessageOfLength(int length) {
        var stream = tcpClient.GetStream();
        bool gotLock = false;
        try
        {
            socketLock.Enter(ref gotLock);
            while (tcpClient.Available < length) { }
            
            byte[] msg = new byte[length];
            stream.ReadExactly(msg, 0, length);
            return msg;
        }
        finally
        {
            if (gotLock) socketLock.Exit();
        }
    }

    /// <summary>
    /// Waits for a message of any length.
    /// </summary>
    private byte[] _WaitForMessage() {
        if (!tcpClient.Connected) {
            throw new InvalidOperationException("TCPClient lost connection");
        }
        
        var stream = tcpClient.GetStream();

        while (tcpClient.Available < sizeof(uint)) { }

        int length = 0;
        {
            byte[] lengthBuf = new byte[sizeof(uint)];
            Trace.Assert(stream.Read(lengthBuf, 0, sizeof(uint)) == sizeof(uint));
            using var reader = new BinaryReader(new MemoryStream(lengthBuf));
            length = reader.ReadInt32();
        }

        while (tcpClient.Available < length) { }

        byte[] buf = new byte[length];
        stream.Read(buf, 0, length);
        return buf;
    }

    public byte[] WaitForMessage() {
        var msg = _WaitForMessage();

        if (msg.Length == 0) {
            return msg;
        }

        //TODO: There's probably a better way to check this, but just do this for now
        if (msg[0] == 7 && msg.Length == 1) {
            CallbacksAvailable = true;
            msg = _WaitForMessage();
        }

        logger.Debug("Got msg " + string.Join(" ", msg));

        return msg;
    }

    public bool BGetCallback(out CallbackMsg_t callback) {
        callback = new();
        
        // lock (commandLock)
        // {
        //     var stream = tcpClient.GetStream();
        //     if (!CallbacksAvailable && stream.DataAvailable) {
        //         byte b = (byte)stream.ReadByte();
        //         if (b == (byte)IPCResponseCode.CallbacksAvailable) {
        //             CallbacksAvailable = true;
        //         }
        //     }

        //     if (CallbacksAvailable) {
        //         CallbacksAvailable = false;
        //         var resp = SendAndWaitForResponse(IPCCommandCode.SerializeCallbacks, []);
        //         logger.Debug("Resp: " + resp.Length);
        //         using var reader = new EndianAwareBinaryReader(new MemoryStream(resp), Utils.Enum.Endianness.Little);
        //         var firstByte = reader.ReadByte();
        //         if (firstByte != 2) {
        //             logger.Debug("CB unknown first byte " + firstByte);
        //         }

        //         callback.steamUser = reader.ReadInt32();
        //         callback.callbackID = reader.ReadInt32();
        //         var len = reader.ReadUInt32();
        //         callback.callbackData = reader.ReadBytes((int)len);

        //         if (stream.DataAvailable) {
        //             byte b = (byte)stream.ReadByte();
        //             if (b == (byte)IPCResponseCode.CallbacksAvailable) {
        //                 logger.Debug("Another callback");
        //                 CallbacksAvailable = true;
        //             }

        //             // byte b2 = (byte)stream.ReadByte();
        //             // if (b2 == (byte)IPCResponseCode.CallbacksAvailable) {
        //             //     logger.Debug("More than 1 callback");
        //             // }
        //         } else {
        //             logger.Debug("No more data");
        //         }

        //         return true;
        //     }
        // }

        return false;
    }
}