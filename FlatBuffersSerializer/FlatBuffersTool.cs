using FlatSharp;

namespace SerializerBenchmarks.FlatBuffersSerializer;

public static class FlatBuffersTool
{
    public static byte[] Serialize(Message message)
    {
        int maxBytesNeeded = FlatBufferSerializer.Default.GetMaxSize(message);
        byte[] buffer = new byte[maxBytesNeeded];
        int bytesWritten = FlatBufferSerializer.Default.Serialize(message, buffer);
        return buffer;
    }

    public static Message Deserialize(byte[] buffer)
    {
        return FlatBufferSerializer.Default.Parse<Message>(buffer);
    }
}