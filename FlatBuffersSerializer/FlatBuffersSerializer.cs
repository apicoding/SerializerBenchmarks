using FlatSharp;

namespace SerializerBenchmarks.FlatBuffersSerializer;

public static class FlatBuffersSerializer
{
    public static byte[] Serialize(MessageFb messageFb)
    {
        int maxBytesNeeded = FlatBufferSerializer.Default.GetMaxSize(messageFb);
        byte[] buffer = new byte[maxBytesNeeded];
        int bytesWritten = FlatBufferSerializer.Default.Serialize(messageFb, buffer);
        return buffer;
    }

    public static MessageFb Deserialize(byte[] buffer)
    {
        return FlatBufferSerializer.Default.Parse<MessageFb>(buffer);
    }
}